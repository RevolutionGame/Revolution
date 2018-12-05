﻿// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: RevProtocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace RevProtocol
{

    /// <summary>Holder for reflection information generated from RevProtocol.proto</summary>
    public static partial class RevProtocolReflection
    {

        #region Descriptor
        /// <summary>File descriptor for RevProtocol.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }
        private static pbr::FileDescriptor descriptor;

        static RevProtocolReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "ChFSZXZQcm90b2NvbC5wcm90bxILUmV2UHJvdG9jb2wiJgoKUGxheWVySW5m",
                  "bxIKCgJpZBgBIAEoDRIMCgRuYW1lGAIgASgJIkEKCUxvYmJ5SW5mbxIKCgJp",
                  "ZBgBIAEoDRIoCgdwbGF5ZXJzGAIgAygLMhcuUmV2UHJvdG9jb2wuUGxheWVy",
                  "SW5mbyI9Cg5QbGF5ZXJMb2NhdGlvbhIKCgJpZBgBIAEoDRIJCgF4GAIgASgC",
                  "EgkKAXkYAyABKAISCQoBchgEIAEoAiLJAQoGUGFja2V0EigKCWJvZHlfdHlw",
                  "ZRgBIAEoDjIVLlJldlByb3RvY29sLkJvZHlUeXBlEi4KC3BsYXllcl9pbmZv",
                  "GAIgASgLMhcuUmV2UHJvdG9jb2wuUGxheWVySW5mb0gAEiwKCmxvYmJ5X2lu",
                  "Zm8YAyABKAsyFi5SZXZQcm90b2NvbC5Mb2JieUluZm9IABIvCghsb2NhdGlv",
                  "bhgEIAEoCzIbLlJldlByb3RvY29sLlBsYXllckxvY2F0aW9uSABCBgoEYm9k",
                  "eSqPAQoIQm9keVR5cGUSDgoKR0FNRV9TVEFSVBAAEgwKCEdBTUVfRU5EEAES",
                  "EAoMUExBWUVSX1JFQURZEAISDwoLUExBWUVSX0pPSU4QAxIOCgpMT0JCWV9J",
                  "TkZPEAQSCwoHUkVBRFlVUBAFEhAKDFJFUVVFU1RfU0xPVBAGEhMKD1BMQVlF",
                  "Ul9MT0NBVElPThAHYgZwcm90bzM="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { },
                new pbr::GeneratedClrTypeInfo(new[] { typeof(global::RevProtocol.BodyType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::RevProtocol.PlayerInfo), global::RevProtocol.PlayerInfo.Parser, new[]{ "Id", "Name" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RevProtocol.LobbyInfo), global::RevProtocol.LobbyInfo.Parser, new[]{ "Id", "Players" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RevProtocol.PlayerLocation), global::RevProtocol.PlayerLocation.Parser, new[]{ "Id", "X", "Y", "R" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RevProtocol.Packet), global::RevProtocol.Packet.Parser, new[]{ "BodyType", "PlayerInfo", "LobbyInfo", "Location" }, new[]{ "Body" }, null, null)
                }));
        }
        #endregion

    }
    #region Enums
    public enum BodyType
    {
        /// <summary>
        ///Starts the game scene
        /// </summary>
        [pbr::OriginalName("GAME_START")] GameStart = 0,
        /// <summary>
        ///Goes back to Main Menu scene
        /// </summary>
        [pbr::OriginalName("GAME_END")] GameEnd = 1,
        /// <summary>
        ///Player is ready in the lobby
        /// </summary>
        [pbr::OriginalName("PLAYER_READY")] PlayerReady = 2,
        /// <summary>
        ///Player has joined lobby
        /// </summary>
        [pbr::OriginalName("PLAYER_JOIN")] PlayerJoin = 3,
        /// <summary>
        ///Send to player after slot request
        /// </summary>
        [pbr::OriginalName("LOBBY_INFO")] LobbyInfo = 4,
        /// <summary>
        ///Send to all players when lobby is full
        /// </summary>
        [pbr::OriginalName("READYUP")] Readyup = 5,
        /// <summary>
        ///Player sends this to request a slot in the lobby
        /// </summary>
        [pbr::OriginalName("REQUEST_SLOT")] RequestSlot = 6,
        /// <summary>
        ///Player coords and rotation for syncing clinets
        /// </summary>
        [pbr::OriginalName("PLAYER_LOCATION")] PlayerLocation = 7,
    }

    #endregion

    #region Messages
    public sealed partial class PlayerInfo : pb::IMessage<PlayerInfo>
    {
        private static readonly pb::MessageParser<PlayerInfo> _parser = new pb::MessageParser<PlayerInfo>(() => new PlayerInfo());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<PlayerInfo> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::RevProtocol.RevProtocolReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public PlayerInfo()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public PlayerInfo(PlayerInfo other) : this()
        {
            id_ = other.id_;
            name_ = other.name_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public PlayerInfo Clone()
        {
            return new PlayerInfo(this);
        }

        /// <summary>Field number for the "id" field.</summary>
        public const int IdFieldNumber = 1;
        private uint id_;
        /// <summary>
        /// player id and space in array
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint Id
        {
            get { return id_; }
            set
            {
                id_ = value;
            }
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 2;
        private string name_ = "";
        /// <summary>
        /// player username
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name
        {
            get { return name_; }
            set
            {
                name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as PlayerInfo);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(PlayerInfo other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Id != other.Id) return false;
            if (Name != other.Name) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Id != 0) hash ^= Id.GetHashCode();
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Id != 0)
            {
                output.WriteRawTag(8);
                output.WriteUInt32(Id);
            }
            if (Name.Length != 0)
            {
                output.WriteRawTag(18);
                output.WriteString(Name);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Id != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
            }
            if (Name.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(PlayerInfo other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Id != 0)
            {
                Id = other.Id;
            }
            if (other.Name.Length != 0)
            {
                Name = other.Name;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 8:
                        {
                            Id = input.ReadUInt32();
                            break;
                        }
                    case 18:
                        {
                            Name = input.ReadString();
                            break;
                        }
                }
            }
        }

    }

    public sealed partial class LobbyInfo : pb::IMessage<LobbyInfo>
    {
        private static readonly pb::MessageParser<LobbyInfo> _parser = new pb::MessageParser<LobbyInfo>(() => new LobbyInfo());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<LobbyInfo> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::RevProtocol.RevProtocolReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LobbyInfo()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LobbyInfo(LobbyInfo other) : this()
        {
            id_ = other.id_;
            players_ = other.players_.Clone();
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LobbyInfo Clone()
        {
            return new LobbyInfo(this);
        }

        /// <summary>Field number for the "id" field.</summary>
        public const int IdFieldNumber = 1;
        private uint id_;
        /// <summary>
        ///id asigned to player after slot request
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint Id
        {
            get { return id_; }
            set
            {
                id_ = value;
            }
        }

        /// <summary>Field number for the "players" field.</summary>
        public const int PlayersFieldNumber = 2;
        private static readonly pb::FieldCodec<global::RevProtocol.PlayerInfo> _repeated_players_codec
            = pb::FieldCodec.ForMessage(18, global::RevProtocol.PlayerInfo.Parser);
        private readonly pbc::RepeatedField<global::RevProtocol.PlayerInfo> players_ = new pbc::RepeatedField<global::RevProtocol.PlayerInfo>();
        /// <summary>
        ///List of players already in lobby
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::RevProtocol.PlayerInfo> Players
        {
            get { return players_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as LobbyInfo);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(LobbyInfo other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Id != other.Id) return false;
            if (!players_.Equals(other.players_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Id != 0) hash ^= Id.GetHashCode();
            hash ^= players_.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Id != 0)
            {
                output.WriteRawTag(8);
                output.WriteUInt32(Id);
            }
            players_.WriteTo(output, _repeated_players_codec);
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Id != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
            }
            size += players_.CalculateSize(_repeated_players_codec);
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(LobbyInfo other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Id != 0)
            {
                Id = other.Id;
            }
            players_.Add(other.players_);
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 8:
                        {
                            Id = input.ReadUInt32();
                            break;
                        }
                    case 18:
                        {
                            players_.AddEntriesFrom(input, _repeated_players_codec);
                            break;
                        }
                }
            }
        }

    }

    public sealed partial class PlayerLocation : pb::IMessage<PlayerLocation>
    {
        private static readonly pb::MessageParser<PlayerLocation> _parser = new pb::MessageParser<PlayerLocation>(() => new PlayerLocation());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<PlayerLocation> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::RevProtocol.RevProtocolReflection.Descriptor.MessageTypes[2]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public PlayerLocation()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public PlayerLocation(PlayerLocation other) : this()
        {
            id_ = other.id_;
            x_ = other.x_;
            y_ = other.y_;
            r_ = other.r_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public PlayerLocation Clone()
        {
            return new PlayerLocation(this);
        }

        /// <summary>Field number for the "id" field.</summary>
        public const int IdFieldNumber = 1;
        private uint id_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint Id
        {
            get { return id_; }
            set
            {
                id_ = value;
            }
        }

        /// <summary>Field number for the "x" field.</summary>
        public const int XFieldNumber = 2;
        private float x_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public float X
        {
            get { return x_; }
            set
            {
                x_ = value;
            }
        }

        /// <summary>Field number for the "y" field.</summary>
        public const int YFieldNumber = 3;
        private float y_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public float Y
        {
            get { return y_; }
            set
            {
                y_ = value;
            }
        }

        /// <summary>Field number for the "r" field.</summary>
        public const int RFieldNumber = 4;
        private float r_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public float R
        {
            get { return r_; }
            set
            {
                r_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as PlayerLocation);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(PlayerLocation other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Id != other.Id) return false;
            if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(X, other.X)) return false;
            if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Y, other.Y)) return false;
            if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(R, other.R)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Id != 0) hash ^= Id.GetHashCode();
            if (X != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(X);
            if (Y != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Y);
            if (R != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(R);
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Id != 0)
            {
                output.WriteRawTag(8);
                output.WriteUInt32(Id);
            }
            if (X != 0F)
            {
                output.WriteRawTag(21);
                output.WriteFloat(X);
            }
            if (Y != 0F)
            {
                output.WriteRawTag(29);
                output.WriteFloat(Y);
            }
            if (R != 0F)
            {
                output.WriteRawTag(37);
                output.WriteFloat(R);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Id != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
            }
            if (X != 0F)
            {
                size += 1 + 4;
            }
            if (Y != 0F)
            {
                size += 1 + 4;
            }
            if (R != 0F)
            {
                size += 1 + 4;
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(PlayerLocation other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Id != 0)
            {
                Id = other.Id;
            }
            if (other.X != 0F)
            {
                X = other.X;
            }
            if (other.Y != 0F)
            {
                Y = other.Y;
            }
            if (other.R != 0F)
            {
                R = other.R;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 8:
                        {
                            Id = input.ReadUInt32();
                            break;
                        }
                    case 21:
                        {
                            X = input.ReadFloat();
                            break;
                        }
                    case 29:
                        {
                            Y = input.ReadFloat();
                            break;
                        }
                    case 37:
                        {
                            R = input.ReadFloat();
                            break;
                        }
                }
            }
        }

    }

    public sealed partial class Packet : pb::IMessage<Packet>
    {
        private static readonly pb::MessageParser<Packet> _parser = new pb::MessageParser<Packet>(() => new Packet());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<Packet> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::RevProtocol.RevProtocolReflection.Descriptor.MessageTypes[3]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Packet()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Packet(Packet other) : this()
        {
            bodyType_ = other.bodyType_;
            switch (other.BodyCase)
            {
                case BodyOneofCase.PlayerInfo:
                    PlayerInfo = other.PlayerInfo.Clone();
                    break;
                case BodyOneofCase.LobbyInfo:
                    LobbyInfo = other.LobbyInfo.Clone();
                    break;
                case BodyOneofCase.Location:
                    Location = other.Location.Clone();
                    break;
            }

            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Packet Clone()
        {
            return new Packet(this);
        }

        /// <summary>Field number for the "body_type" field.</summary>
        public const int BodyTypeFieldNumber = 1;
        private global::RevProtocol.BodyType bodyType_ = 0;
        /// <summary>
        ///Type of packet this is
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::RevProtocol.BodyType BodyType
        {
            get { return bodyType_; }
            set
            {
                bodyType_ = value;
            }
        }

        /// <summary>Field number for the "player_info" field.</summary>
        public const int PlayerInfoFieldNumber = 2;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::RevProtocol.PlayerInfo PlayerInfo
        {
            get { return bodyCase_ == BodyOneofCase.PlayerInfo ? (global::RevProtocol.PlayerInfo)body_ : null; }
            set
            {
                body_ = value;
                bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.PlayerInfo;
            }
        }

        /// <summary>Field number for the "lobby_info" field.</summary>
        public const int LobbyInfoFieldNumber = 3;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::RevProtocol.LobbyInfo LobbyInfo
        {
            get { return bodyCase_ == BodyOneofCase.LobbyInfo ? (global::RevProtocol.LobbyInfo)body_ : null; }
            set
            {
                body_ = value;
                bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.LobbyInfo;
            }
        }

        /// <summary>Field number for the "location" field.</summary>
        public const int LocationFieldNumber = 4;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::RevProtocol.PlayerLocation Location
        {
            get { return bodyCase_ == BodyOneofCase.Location ? (global::RevProtocol.PlayerLocation)body_ : null; }
            set
            {
                body_ = value;
                bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.Location;
            }
        }

        private object body_;
        /// <summary>Enum of possible cases for the "body" oneof.</summary>
        public enum BodyOneofCase
        {
            None = 0,
            PlayerInfo = 2,
            LobbyInfo = 3,
            Location = 4,
        }
        private BodyOneofCase bodyCase_ = BodyOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public BodyOneofCase BodyCase
        {
            get { return bodyCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearBody()
        {
            bodyCase_ = BodyOneofCase.None;
            body_ = null;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as Packet);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Packet other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (BodyType != other.BodyType) return false;
            if (!object.Equals(PlayerInfo, other.PlayerInfo)) return false;
            if (!object.Equals(LobbyInfo, other.LobbyInfo)) return false;
            if (!object.Equals(Location, other.Location)) return false;
            if (BodyCase != other.BodyCase) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (BodyType != 0) hash ^= BodyType.GetHashCode();
            if (bodyCase_ == BodyOneofCase.PlayerInfo) hash ^= PlayerInfo.GetHashCode();
            if (bodyCase_ == BodyOneofCase.LobbyInfo) hash ^= LobbyInfo.GetHashCode();
            if (bodyCase_ == BodyOneofCase.Location) hash ^= Location.GetHashCode();
            hash ^= (int)bodyCase_;
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (BodyType != 0)
            {
                output.WriteRawTag(8);
                output.WriteEnum((int)BodyType);
            }
            if (bodyCase_ == BodyOneofCase.PlayerInfo)
            {
                output.WriteRawTag(18);
                output.WriteMessage(PlayerInfo);
            }
            if (bodyCase_ == BodyOneofCase.LobbyInfo)
            {
                output.WriteRawTag(26);
                output.WriteMessage(LobbyInfo);
            }
            if (bodyCase_ == BodyOneofCase.Location)
            {
                output.WriteRawTag(34);
                output.WriteMessage(Location);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (BodyType != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeEnumSize((int)BodyType);
            }
            if (bodyCase_ == BodyOneofCase.PlayerInfo)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(PlayerInfo);
            }
            if (bodyCase_ == BodyOneofCase.LobbyInfo)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(LobbyInfo);
            }
            if (bodyCase_ == BodyOneofCase.Location)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(Location);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Packet other)
        {
            if (other == null)
            {
                return;
            }
            if (other.BodyType != 0)
            {
                BodyType = other.BodyType;
            }
            switch (other.BodyCase)
            {
                case BodyOneofCase.PlayerInfo:
                    if (PlayerInfo == null)
                    {
                        PlayerInfo = new global::RevProtocol.PlayerInfo();
                    }
                    PlayerInfo.MergeFrom(other.PlayerInfo);
                    break;
                case BodyOneofCase.LobbyInfo:
                    if (LobbyInfo == null)
                    {
                        LobbyInfo = new global::RevProtocol.LobbyInfo();
                    }
                    LobbyInfo.MergeFrom(other.LobbyInfo);
                    break;
                case BodyOneofCase.Location:
                    if (Location == null)
                    {
                        Location = new global::RevProtocol.PlayerLocation();
                    }
                    Location.MergeFrom(other.Location);
                    break;
            }

            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 8:
                        {
                            bodyType_ = (global::RevProtocol.BodyType)input.ReadEnum();
                            break;
                        }
                    case 18:
                        {
                            global::RevProtocol.PlayerInfo subBuilder = new global::RevProtocol.PlayerInfo();
                            if (bodyCase_ == BodyOneofCase.PlayerInfo)
                            {
                                subBuilder.MergeFrom(PlayerInfo);
                            }
                            input.ReadMessage(subBuilder);
                            PlayerInfo = subBuilder;
                            break;
                        }
                    case 26:
                        {
                            global::RevProtocol.LobbyInfo subBuilder = new global::RevProtocol.LobbyInfo();
                            if (bodyCase_ == BodyOneofCase.LobbyInfo)
                            {
                                subBuilder.MergeFrom(LobbyInfo);
                            }
                            input.ReadMessage(subBuilder);
                            LobbyInfo = subBuilder;
                            break;
                        }
                    case 34:
                        {
                            global::RevProtocol.PlayerLocation subBuilder = new global::RevProtocol.PlayerLocation();
                            if (bodyCase_ == BodyOneofCase.Location)
                            {
                                subBuilder.MergeFrom(Location);
                            }
                            input.ReadMessage(subBuilder);
                            Location = subBuilder;
                            break;
                        }
                }
            }
        }

    }

    #endregion

}

#endregion Designer generated code

