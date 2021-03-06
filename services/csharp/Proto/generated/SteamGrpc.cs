// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: auth/steam.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Improbable.OnlineServices.Proto.Auth.Steam {
  public static partial class AuthService
  {
    static readonly string __ServiceName = "auth.steam.AuthService";

    static readonly grpc::Marshaller<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest> __Marshaller_auth_steam_ExchangeSteamTokenRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse> __Marshaller_auth_steam_ExchangeSteamTokenResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest, global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse> __Method_ExchangeSteamToken = new grpc::Method<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest, global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ExchangeSteamToken",
        __Marshaller_auth_steam_ExchangeSteamTokenRequest,
        __Marshaller_auth_steam_ExchangeSteamTokenResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Improbable.OnlineServices.Proto.Auth.Steam.SteamReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AuthService</summary>
    [grpc::BindServiceMethod(typeof(AuthService), "BindService")]
    public abstract partial class AuthServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse> ExchangeSteamToken(global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for AuthService</summary>
    public partial class AuthServiceClient : grpc::ClientBase<AuthServiceClient>
    {
      /// <summary>Creates a new client for AuthService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public AuthServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for AuthService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public AuthServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected AuthServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected AuthServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse ExchangeSteamToken(global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ExchangeSteamToken(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse ExchangeSteamToken(global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ExchangeSteamToken, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse> ExchangeSteamTokenAsync(global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ExchangeSteamTokenAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse> ExchangeSteamTokenAsync(global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ExchangeSteamToken, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override AuthServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new AuthServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(AuthServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ExchangeSteamToken, serviceImpl.ExchangeSteamToken).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AuthServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ExchangeSteamToken, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenRequest, global::Improbable.OnlineServices.Proto.Auth.Steam.ExchangeSteamTokenResponse>(serviceImpl.ExchangeSteamToken));
    }

  }
}
#endregion
