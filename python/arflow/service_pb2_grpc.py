# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

from arflow import service_pb2 as arflow_dot_service__pb2


class ARFlowServiceStub(object):
    """The ARFlowService service definition.
    """

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.register = channel.unary_unary(
                '/ARFlowService/register',
                request_serializer=arflow_dot_service__pb2.RegisterRequest.SerializeToString,
                response_deserializer=arflow_dot_service__pb2.RegisterResponse.FromString,
                )
        self.data_frame = channel.unary_unary(
                '/ARFlowService/data_frame',
                request_serializer=arflow_dot_service__pb2.DataFrameRequest.SerializeToString,
                response_deserializer=arflow_dot_service__pb2.DataFrameResponse.FromString,
                )


class ARFlowServiceServicer(object):
    """The ARFlowService service definition.
    """

    def register(self, request, context):
        """Registers a device with the given specifications.
        """
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def data_frame(self, request, context):
        """Sends a data frame from a device.
        """
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_ARFlowServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'register': grpc.unary_unary_rpc_method_handler(
                    servicer.register,
                    request_deserializer=arflow_dot_service__pb2.RegisterRequest.FromString,
                    response_serializer=arflow_dot_service__pb2.RegisterResponse.SerializeToString,
            ),
            'data_frame': grpc.unary_unary_rpc_method_handler(
                    servicer.data_frame,
                    request_deserializer=arflow_dot_service__pb2.DataFrameRequest.FromString,
                    response_serializer=arflow_dot_service__pb2.DataFrameResponse.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'ARFlowService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class ARFlowService(object):
    """The ARFlowService service definition.
    """

    @staticmethod
    def register(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/ARFlowService/register',
            arflow_dot_service__pb2.RegisterRequest.SerializeToString,
            arflow_dot_service__pb2.RegisterResponse.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def data_frame(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/ARFlowService/data_frame',
            arflow_dot_service__pb2.DataFrameRequest.SerializeToString,
            arflow_dot_service__pb2.DataFrameResponse.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)
