"""A library for replaying ARFlow data."""

import pickle
import threading
import time
from pathlib import Path

from arflow.core import ARFlowServicer
from arflow.service_pb2 import ClientConfiguration, DataFrame
from arflow.types import EnrichedARFlowRequest, RequestsHistory, Timestamp


class ARFlowPlayer(threading.Thread):
    """A class for replaying ARFlow data."""

    def __init__(self, frame_data_path: Path) -> None:
        super().__init__()
        self._service = ARFlowServicer()
        self._requests_history: RequestsHistory = []
        with open(frame_data_path, "rb") as f:
            raw_data: RequestsHistory = pickle.load(f)

        start_delta = 0
        for i, data in enumerate(raw_data):
            if i == 0:
                start_delta = data["timestamp"] - 3
                self._requests_history.append(
                    EnrichedARFlowRequest(
                        timestamp=Timestamp(data["timestamp"] - start_delta),
                        data=data["data"],
                    )
                )
            else:
                self._requests_history.append(
                    EnrichedARFlowRequest(
                        timestamp=Timestamp(data["timestamp"] - start_delta),
                        data=data["data"],
                    )
                )

        # TODO: Fix this
        self.uid = self.frame_data[1]["data"].uid  # type: ignore

        self.period = 0.001  # Simulate a 1ms loop.
        self.n_frame = 0

        self.i = 0
        self.t0 = time.time()
        self.start()

    def sleep(self):
        self.i += 1
        delta = self.t0 + self.period * self.i - time.time()
        if delta > 0:
            time.sleep(delta)

    def run(self):
        while True:
            current_time = time.time() - self.t0

            t = self._requests_history[self.n_frame]["timestamp"]

            if t - current_time < 0.001:
                data = self._requests_history[self.n_frame]["data"]
                if self.n_frame == 0 and isinstance(data, ClientConfiguration):
                    self._service.RegisterClient(data, None, init_uid=self.uid)
                elif isinstance(data, DataFrame):
                    self._service.ProcessFrame(data, None)
                else:
                    raise ValueError("Unknown request data type.")

                self.n_frame += 1

            if self.n_frame > len(self._requests_history) - 1:
                break

            self.sleep()

        print("Reply finished.")
        exit()
