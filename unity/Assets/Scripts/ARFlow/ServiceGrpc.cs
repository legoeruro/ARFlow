// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/arflow/service.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ARFlow {
  /// <summary>
  /// The ARFlow service definition.
  /// </summary>
  public static partial class ARFlow
  {
    static readonly string __ServiceName = "arflow.ARFlow";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ARFlow.ClientConfiguration> __Marshaller_arflow_ClientConfiguration = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ARFlow.ClientConfiguration.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ARFlow.ClientIdentifier> __Marshaller_arflow_ClientIdentifier = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ARFlow.ClientIdentifier.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ARFlow.DataFrame> __Marshaller_arflow_DataFrame = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ARFlow.DataFrame.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ARFlow.Acknowledgement> __Marshaller_arflow_Acknowledgement = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ARFlow.Acknowledgement.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ARFlow.ClientConfiguration, global::ARFlow.ClientIdentifier> __Method_RegisterClient = new grpc::Method<global::ARFlow.ClientConfiguration, global::ARFlow.ClientIdentifier>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RegisterClient",
        __Marshaller_arflow_ClientConfiguration,
        __Marshaller_arflow_ClientIdentifier);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ARFlow.DataFrame, global::ARFlow.Acknowledgement> __Method_ProcessFrame = new grpc::Method<global::ARFlow.DataFrame, global::ARFlow.Acknowledgement>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ProcessFrame",
        __Marshaller_arflow_DataFrame,
        __Marshaller_arflow_Acknowledgement);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ARFlow.ServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ARFlow</summary>
    [grpc::BindServiceMethod(typeof(ARFlow), "BindService")]
    public abstract partial class ARFlowBase
    {
      /// <summary>
      /// Registers a client with the given specifications.
      ///
      /// The client is registered with the server and is assigned a unique identifier.
      /// The client can then send data frames to the server using the assigned identifier.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ARFlow.ClientIdentifier> RegisterClient(global::ARFlow.ClientConfiguration request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Accepts a data frame from a client, returning an acknowledgment.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ARFlow.Acknowledgement> ProcessFrame(global::ARFlow.DataFrame request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ARFlow</summary>
    public partial class ARFlowClient : grpc::ClientBase<ARFlowClient>
    {
      /// <summary>Creates a new client for ARFlow</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ARFlowClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ARFlow that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ARFlowClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ARFlowClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ARFlowClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Registers a client with the given specifications.
      ///
      /// The client is registered with the server and is assigned a unique identifier.
      /// The client can then send data frames to the server using the assigned identifier.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ARFlow.ClientIdentifier RegisterClient(global::ARFlow.ClientConfiguration request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterClient(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Registers a client with the given specifications.
      ///
      /// The client is registered with the server and is assigned a unique identifier.
      /// The client can then send data frames to the server using the assigned identifier.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ARFlow.ClientIdentifier RegisterClient(global::ARFlow.ClientConfiguration request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RegisterClient, null, options, request);
      }
      /// <summary>
      /// Registers a client with the given specifications.
      ///
      /// The client is registered with the server and is assigned a unique identifier.
      /// The client can then send data frames to the server using the assigned identifier.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ARFlow.ClientIdentifier> RegisterClientAsync(global::ARFlow.ClientConfiguration request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterClientAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Registers a client with the given specifications.
      ///
      /// The client is registered with the server and is assigned a unique identifier.
      /// The client can then send data frames to the server using the assigned identifier.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ARFlow.ClientIdentifier> RegisterClientAsync(global::ARFlow.ClientConfiguration request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RegisterClient, null, options, request);
      }
      /// <summary>
      /// Accepts a data frame from a client, returning an acknowledgment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ARFlow.Acknowledgement ProcessFrame(global::ARFlow.DataFrame request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ProcessFrame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Accepts a data frame from a client, returning an acknowledgment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ARFlow.Acknowledgement ProcessFrame(global::ARFlow.DataFrame request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ProcessFrame, null, options, request);
      }
      /// <summary>
      /// Accepts a data frame from a client, returning an acknowledgment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ARFlow.Acknowledgement> ProcessFrameAsync(global::ARFlow.DataFrame request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ProcessFrameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Accepts a data frame from a client, returning an acknowledgment.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ARFlow.Acknowledgement> ProcessFrameAsync(global::ARFlow.DataFrame request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ProcessFrame, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ARFlowClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ARFlowClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ARFlowBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RegisterClient, serviceImpl.RegisterClient)
          .AddMethod(__Method_ProcessFrame, serviceImpl.ProcessFrame).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ARFlowBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_RegisterClient, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ARFlow.ClientConfiguration, global::ARFlow.ClientIdentifier>(serviceImpl.RegisterClient));
      serviceBinder.AddMethod(__Method_ProcessFrame, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ARFlow.DataFrame, global::ARFlow.Acknowledgement>(serviceImpl.ProcessFrame));
    }

  }
}
#endregion
