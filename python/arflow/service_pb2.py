# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: arflow/service.proto
# Protobuf Python Version: 4.25.0
"""Generated protocol buffer code."""
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import symbol_database as _symbol_database
from google.protobuf.internal import builder as _builder
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\x14\x61rflow/service.proto\"\x93\x05\n\x0fRegisterRequest\x12\x13\n\x0b\x64\x65vice_name\x18\x01 \x01(\t\x12/\n\nintrinsics\x18\x02 \x01(\x0b\x32\x1b.RegisterRequest.Intrinsics\x12\x32\n\x0c\x63\x61mera_color\x18\x03 \x01(\x0b\x32\x1c.RegisterRequest.CameraColor\x12\x32\n\x0c\x63\x61mera_depth\x18\x04 \x01(\x0b\x32\x1c.RegisterRequest.CameraDepth\x12:\n\x10\x63\x61mera_transform\x18\x05 \x01(\x0b\x32 .RegisterRequest.CameraTransform\x1a\xe6\x01\n\nIntrinsics\x12\x16\n\x0e\x66ocal_length_x\x18\x01 \x01(\x02\x12\x16\n\x0e\x66ocal_length_y\x18\x02 \x01(\x02\x12\x19\n\x11principal_point_x\x18\x03 \x01(\x02\x12\x19\n\x11principal_point_y\x18\x04 \x01(\x02\x12\x1b\n\x13native_resolution_x\x18\x05 \x01(\x05\x12\x1b\n\x13native_resolution_y\x18\x06 \x01(\x05\x12\x1b\n\x13sample_resolution_x\x18\x07 \x01(\x05\x12\x1b\n\x13sample_resolution_y\x18\x08 \x01(\x05\x1a\x31\n\x0b\x43\x61meraColor\x12\x0f\n\x07\x65nabled\x18\x01 \x01(\x08\x12\x11\n\tdata_type\x18\x02 \x01(\x05\x1aV\n\x0b\x43\x61meraDepth\x12\x0f\n\x07\x65nabled\x18\x01 \x01(\x08\x12\x12\n\ndata_depth\x18\x02 \x01(\x05\x12\"\n\x1a\x63onfidence_filtering_level\x18\x03 \x01(\x05\x1a\"\n\x0f\x43\x61meraTransform\x12\x0f\n\x07\x65nabled\x18\x01 \x01(\x08\"#\n\x10RegisterResponse\x12\x0f\n\x07message\x18\x01 \x01(\t\"\x81\x01\n\x10\x44\x61taFrameRequest\x12\x0b\n\x03uid\x18\x01 \x01(\t\x12\x12\n\x05\x63olor\x18\x02 \x01(\x0cH\x00\x88\x01\x01\x12\x12\n\x05\x64\x65pth\x18\x03 \x01(\x0cH\x01\x88\x01\x01\x12\x16\n\ttransform\x18\x04 \x01(\x0cH\x02\x88\x01\x01\x42\x08\n\x06_colorB\x08\n\x06_depthB\x0c\n\n_transform\"$\n\x11\x44\x61taFrameResponse\x12\x0f\n\x07message\x18\x01 \x01(\t2u\n\rARFlowService\x12/\n\x08register\x12\x10.RegisterRequest\x1a\x11.RegisterResponse\x12\x33\n\ndata_frame\x12\x11.DataFrameRequest\x1a\x12.DataFrameResponseB\t\xaa\x02\x06\x41RFlowb\x06proto3')

_globals = globals()
_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, _globals)
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'arflow.service_pb2', _globals)
if _descriptor._USE_C_DESCRIPTORS == False:
  _globals['DESCRIPTOR']._options = None
  _globals['DESCRIPTOR']._serialized_options = b'\252\002\006ARFlow'
  _globals['_REGISTERREQUEST']._serialized_start=25
  _globals['_REGISTERREQUEST']._serialized_end=684
  _globals['_REGISTERREQUEST_INTRINSICS']._serialized_start=279
  _globals['_REGISTERREQUEST_INTRINSICS']._serialized_end=509
  _globals['_REGISTERREQUEST_CAMERACOLOR']._serialized_start=511
  _globals['_REGISTERREQUEST_CAMERACOLOR']._serialized_end=560
  _globals['_REGISTERREQUEST_CAMERADEPTH']._serialized_start=562
  _globals['_REGISTERREQUEST_CAMERADEPTH']._serialized_end=648
  _globals['_REGISTERREQUEST_CAMERATRANSFORM']._serialized_start=650
  _globals['_REGISTERREQUEST_CAMERATRANSFORM']._serialized_end=684
  _globals['_REGISTERRESPONSE']._serialized_start=686
  _globals['_REGISTERRESPONSE']._serialized_end=721
  _globals['_DATAFRAMEREQUEST']._serialized_start=724
  _globals['_DATAFRAMEREQUEST']._serialized_end=853
  _globals['_DATAFRAMERESPONSE']._serialized_start=855
  _globals['_DATAFRAMERESPONSE']._serialized_end=891
  _globals['_ARFLOWSERVICE']._serialized_start=893
  _globals['_ARFLOWSERVICE']._serialized_end=1010
# @@protoc_insertion_point(module_scope)
