﻿//
// Copyright 2021-2023 Picovoice Inc.
//
// You may not use this file except in compliance with the license. A copy of the license is located in the "LICENSE"
// file accompanying this source.
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Pv.Unity
{
    /// <summary>
    /// Listener type that can be added to VoiceProcessor with `.addFrameListener()`. Captures audio
    /// frames that are generated by the recording thread.
    /// </summary>
    public delegate void VoiceProcessorFrameListener(float[] frame);

    /// <summary>
    /// Class that records audio and delivers frames for real-time audio processing
    /// </summary>
    public class VoiceProcessor : MonoBehaviour
    {

        private AudioSource _audioSource;
        private event Action _onRestartRecording;
        private event VoiceProcessorFrameListener _onFrame;

        /// Available audio recording devices.
        /// </summary>
        public List<string> Devices { get; private set; }

        /// <summary>
        /// Index of selected audio recording device.
        /// </summary>
        public int CurrentDeviceIndex { get; private set; }

        /// <summary>
        /// Name of selected audio recording device.
        /// </summary>
        public string CurrentDeviceName
        {
            get
            {
                if (CurrentDeviceIndex < 0 || CurrentDeviceIndex >= Microphone.devices.Length)
                    return string.Empty;
                return Devices[CurrentDeviceIndex];
            }
        }

        /// <summary>
        /// Sample rate of recorded audio
        /// </summary>
        public int SampleRate { get; private set; }

        /// <summary>
        /// Size of audio frames that are delivered
        /// </summary>
        public int FrameLength { get; private set; }

        /// <summary>
        /// The number of registered `VoiceProcessorFrameListeners`.
        /// </summary>
        public int NumFrameListeners
        {
            get
            {
                if (_onFrame == null)
                {
                    return 0;
                }
                return _onFrame.GetInvocationList().Length;
            }
        }

        /// <summary>
        /// Mixer to manage microphone audio.
        /// </summary>
        private AudioMixerGroup _voiceProcessorMixer;

        /// <summary>
        /// Indicates whether microphone is capturing or not.
        /// </summary>
        public bool IsRecording
        {
            get
            {
                return _audioSource.clip != null && Microphone.IsRecording(CurrentDeviceName);
            }
        }

        /// <summary>
        /// Singleton instance of the VoiceProcessor.
        /// </summary>
        static VoiceProcessor _instance;

        public static VoiceProcessor Instance
        {
            get
            {
                if (_instance == null) FindObjectOfType<VoiceProcessor>();
                if (_instance == null)
                {
                    _instance = new GameObject("Pv.Unity.VoiceProcessor").AddComponent<VoiceProcessor>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Add a frame listener that will receive audio frames generated by the VoiceProcessor.
        /// </summary>
        /// <param name="listener">`VoiceProcessorFrameListener` for processing frames of audio.</param>
        public void AddFrameListener(VoiceProcessorFrameListener listener)
        {
            _onFrame += listener;
        }

        /// <summary>
        /// Add multiple frame listeners that will receive audio frames generated by the VoiceProcessor.
        /// </summary>
        /// <param name="listeners">`VoiceProcessorFrameListeners` for processing frames of audio.</param>
        public void AddFrameListeners(VoiceProcessorFrameListener[] listeners)
        {
            foreach (var listener in listeners)
            {
                _onFrame += listener;
            }
        }

        /// <summary>
        /// Remove a frame listener from the VoiceProcessor. It will no longer receive audio frames.
        /// </summary>
        /// <param name="listener">`VoiceProcessorFrameListener` that you would like to remove.</param>
        public void RemoveFrameListener(VoiceProcessorFrameListener listener)
        {
            _onFrame -= listener;
        }

        /// <summary>
        /// Remove frame listeners from the VoiceProcessor. They will no longer receive audio frames.
        /// </summary>
        /// <param name="listeners">`VoiceProcessorFrameListeners` that you would like to remove.</param>
        public void RemoveFrameListeners(VoiceProcessorFrameListener[] listeners)
        {
            foreach (var listener in listeners)
            {
                _onFrame -= listener;
            }
        }

        /// <summary>
        /// Clears all currently registered frame listeners.
        /// </summary>
        public void ClearFrameListeners()
        {
            _onFrame = null;
        }

        /// <summary>
        /// Starts audio recording with the specified audio properties.
        /// </summary>
        /// <param name="frameLength">The length of each audio frame, in number of samples.</param>
        /// <param name="sampleRate">The sample rate to record audio at, in Hz.</param>
        public void StartRecording(int frameLength, int sampleRate)
        {
            if (IsRecording)
            {
                // if sample rate or frame size have changed, restart recording
                if (sampleRate != SampleRate || frameLength != FrameLength)
                {
                    throw new VoiceProcessorArgumentException(
                        String.Format(
                            "VoiceProcessor StartRecording() was called with frame length " +
                                        "%d and sample rate %d while already recording with " +
                                        "frame length %d and sample rate %d",
                            frameLength,
                            sampleRate,
                            FrameLength,
                            SampleRate));
                }
                return;
            }

            SampleRate = sampleRate;
            FrameLength = frameLength;

            _audioSource.clip = Microphone.Start(CurrentDeviceName, true, 1, sampleRate);
            _audioSource.outputAudioMixerGroup = _voiceProcessorMixer;

            StartCoroutine(RecordData());
        }

        /// <summary>
        /// Stops audio recording and releases audio resources.
        /// </summary>
        public void StopRecording()
        {
            if (!IsRecording)
                return;

            Microphone.End(CurrentDeviceName);
            Destroy(_audioSource.clip);
            _audioSource.clip = null;

            StopCoroutine(RecordData());
        }

        /// <summary>
        /// Basic Voice Processor setup on init.
        /// </summary>
        public void Awake()
        {
            if (_audioSource == null) GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            UpdateDevices();
        }

        /// <summary>
        /// Updates list of available audio devices.
        /// </summary>
        public void UpdateDevices()
        {
            Devices = new List<string>();
            foreach (var device in Microphone.devices)
            {
                Devices.Add(device);
            }

            if (Devices == null || Devices.Count == 0)
            {
                CurrentDeviceIndex = -1;
                throw new VoiceProcessorStateException(
                    "There is no valid recording device connected");
            }

            CurrentDeviceIndex = 0;
        }

        /// <summary>
        /// Change audio recording device.
        /// Unlike the original package code, WE ARE REMODIFYING THE EVENT HANDLER TO RECEIVE FLOAT.
        /// </summary>
        /// <param name="deviceIndex">Index of the new audio capture device.</param>
        public void ChangeDevice(int deviceIndex)
        {
            if (deviceIndex < 0 || deviceIndex >= Devices.Count)
            {
                throw new VoiceProcessorArgumentException(
                    string.Format("Specified device index {0} is not a valid recording device", deviceIndex));
            }

            if (IsRecording)
            {
                // one time event to restart recording with the new device
                // the moment the last session has completed
                _onRestartRecording += () =>
                {
                    CurrentDeviceIndex = deviceIndex;
                    StartRecording(FrameLength, SampleRate);
                    _onRestartRecording = null;
                };
                StopRecording();
            }
            else
            {
                CurrentDeviceIndex = deviceIndex;
            }
        }

        /// <summary>
        /// Loop for buffering incoming audio data and delivering frames.
        /// </summary>
        private IEnumerator RecordData()
        {
            float[] sampleFrame = new float[FrameLength];
            int startReadPos = 0;

            while (IsRecording)
            {
                int curClipPos = Microphone.GetPosition(CurrentDeviceName);
                if (curClipPos < startReadPos)
                    curClipPos += _audioSource.clip.samples;

                int samplesAvailable = curClipPos - startReadPos;
                if (samplesAvailable < FrameLength)
                {
                    yield return null;
                    continue;
                }

                int endReadPos = startReadPos + FrameLength;
                if (endReadPos > _audioSource.clip.samples)
                {
                    // fragmented read (wraps around to beginning of clip)
                    // read bit at end of clip
                    int numSamplesClipEnd = _audioSource.clip.samples - startReadPos;
                    float[] endClipSamples = new float[numSamplesClipEnd];
                    _audioSource.clip.GetData(endClipSamples, startReadPos);

                    // read bit at start of clip
                    int numSamplesClipStart = endReadPos - _audioSource.clip.samples;
                    float[] startClipSamples = new float[numSamplesClipStart];
                    _audioSource.clip.GetData(startClipSamples, 0);

                    // combine to form full frame
                    Buffer.BlockCopy(endClipSamples, 0, sampleFrame, 0, numSamplesClipEnd);
                    Buffer.BlockCopy(startClipSamples, 0, sampleFrame, numSamplesClipEnd, numSamplesClipStart);
                }
                else
                {
                    _audioSource.clip.GetData(sampleFrame, startReadPos);
                }

                startReadPos = endReadPos % _audioSource.clip.samples;

                // converts to 16-bit int samples
                //short[] frame = new short[sampleFrame.Length];
                //for (int i = 0; i < FrameLength; i++)
                //{
                //    frame[i] = (short)Math.Floor(sampleFrame[i] * short.MaxValue);
                //}

                _onFrame?.Invoke(sampleFrame);
            }

            _onRestartRecording?.Invoke();
        }
    }
}