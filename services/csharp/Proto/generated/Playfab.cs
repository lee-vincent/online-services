// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: auth/playfab.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Improbable.OnlineServices.Proto.Auth.PlayFab {

  /// <summary>Holder for reflection information generated from auth/playfab.proto</summary>
  public static partial class PlayfabReflection {

    #region Descriptor
    /// <summary>File descriptor for auth/playfab.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PlayfabReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJhdXRoL3BsYXlmYWIucHJvdG8SDGF1dGgucGxheWZhYhocZ29vZ2xlL2Fw",
            "aS9hbm5vdGF0aW9ucy5wcm90byI0ChtFeGNoYW5nZVBsYXlGYWJUb2tlblJl",
            "cXVlc3QSFQoNcGxheWZhYl90b2tlbhgBIAEoCSI9ChxFeGNoYW5nZVBsYXlG",
            "YWJUb2tlblJlc3BvbnNlEh0KFXBsYXllcl9pZGVudGl0eV90b2tlbhgBIAEo",
            "CTKkAQoLQXV0aFNlcnZpY2USlAEKFEV4Y2hhbmdlUGxheUZhYlRva2VuEiku",
            "YXV0aC5wbGF5ZmFiLkV4Y2hhbmdlUGxheUZhYlRva2VuUmVxdWVzdBoqLmF1",
            "dGgucGxheWZhYi5FeGNoYW5nZVBsYXlGYWJUb2tlblJlc3BvbnNlIiWC0+ST",
            "Ah8iGi92MS9leGNoYW5nZV9wbGF5ZmFiX3Rva2VuOgEqQi+qAixJbXByb2Jh",
            "YmxlLk9ubGluZVNlcnZpY2VzLlByb3RvLkF1dGguUGxheUZhYmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Improbable.OnlineServices.Proto.Auth.PlayFab.ExchangePlayFabTokenRequest), global::Improbable.OnlineServices.Proto.Auth.PlayFab.ExchangePlayFabTokenRequest.Parser, new[]{ "PlayfabToken" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Improbable.OnlineServices.Proto.Auth.PlayFab.ExchangePlayFabTokenResponse), global::Improbable.OnlineServices.Proto.Auth.PlayFab.ExchangePlayFabTokenResponse.Parser, new[]{ "PlayerIdentityToken" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ExchangePlayFabTokenRequest : pb::IMessage<ExchangePlayFabTokenRequest> {
    private static readonly pb::MessageParser<ExchangePlayFabTokenRequest> _parser = new pb::MessageParser<ExchangePlayFabTokenRequest>(() => new ExchangePlayFabTokenRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExchangePlayFabTokenRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Improbable.OnlineServices.Proto.Auth.PlayFab.PlayfabReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExchangePlayFabTokenRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExchangePlayFabTokenRequest(ExchangePlayFabTokenRequest other) : this() {
      playfabToken_ = other.playfabToken_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExchangePlayFabTokenRequest Clone() {
      return new ExchangePlayFabTokenRequest(this);
    }

    /// <summary>Field number for the "playfab_token" field.</summary>
    public const int PlayfabTokenFieldNumber = 1;
    private string playfabToken_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PlayfabToken {
      get { return playfabToken_; }
      set {
        playfabToken_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExchangePlayFabTokenRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExchangePlayFabTokenRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (PlayfabToken != other.PlayfabToken) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (PlayfabToken.Length != 0) hash ^= PlayfabToken.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (PlayfabToken.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(PlayfabToken);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (PlayfabToken.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PlayfabToken);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExchangePlayFabTokenRequest other) {
      if (other == null) {
        return;
      }
      if (other.PlayfabToken.Length != 0) {
        PlayfabToken = other.PlayfabToken;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            PlayfabToken = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ExchangePlayFabTokenResponse : pb::IMessage<ExchangePlayFabTokenResponse> {
    private static readonly pb::MessageParser<ExchangePlayFabTokenResponse> _parser = new pb::MessageParser<ExchangePlayFabTokenResponse>(() => new ExchangePlayFabTokenResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExchangePlayFabTokenResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Improbable.OnlineServices.Proto.Auth.PlayFab.PlayfabReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExchangePlayFabTokenResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExchangePlayFabTokenResponse(ExchangePlayFabTokenResponse other) : this() {
      playerIdentityToken_ = other.playerIdentityToken_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExchangePlayFabTokenResponse Clone() {
      return new ExchangePlayFabTokenResponse(this);
    }

    /// <summary>Field number for the "player_identity_token" field.</summary>
    public const int PlayerIdentityTokenFieldNumber = 1;
    private string playerIdentityToken_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PlayerIdentityToken {
      get { return playerIdentityToken_; }
      set {
        playerIdentityToken_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExchangePlayFabTokenResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExchangePlayFabTokenResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (PlayerIdentityToken != other.PlayerIdentityToken) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (PlayerIdentityToken.Length != 0) hash ^= PlayerIdentityToken.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (PlayerIdentityToken.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(PlayerIdentityToken);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (PlayerIdentityToken.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PlayerIdentityToken);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExchangePlayFabTokenResponse other) {
      if (other == null) {
        return;
      }
      if (other.PlayerIdentityToken.Length != 0) {
        PlayerIdentityToken = other.PlayerIdentityToken;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            PlayerIdentityToken = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
