using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;
using McProtoNet.Protocol.Types;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("SpawnEntity", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class SpawnEntityPacket : IServerPacket
    {
        public int EntityId { get; set; }
        public Guid ObjectUUID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public sbyte Pitch { get; set; }
        public sbyte Yaw { get; set; }
        public int ObjectData { get; set; }
        public short VelocityX { get; set; }
        public short VelocityY { get; set; }
        public short VelocityZ { get; set; }

        [PacketSubInfo(340, 404)]
        public sealed partial class V340_404 : SpawnEntityPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                EntityId = reader.ReadVarInt();
                ObjectUUID = reader.ReadUUID();
                Type = reader.ReadSignedByte();
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
                Pitch = reader.ReadSignedByte();
                Yaw = reader.ReadSignedByte();
                ObjectData = reader.ReadSignedInt();
                VelocityX = reader.ReadSignedShort();
                VelocityY = reader.ReadSignedShort();
                VelocityZ = reader.ReadSignedShort();
            }

            public sbyte Type { get; set; }
        }

        [PacketSubInfo(477, 758)]
        public sealed partial class V477_758 : SpawnEntityPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                EntityId = reader.ReadVarInt();
                ObjectUUID = reader.ReadUUID();
                Type = reader.ReadVarInt();
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
                Pitch = reader.ReadSignedByte();
                Yaw = reader.ReadSignedByte();
                ObjectData = reader.ReadSignedInt();
                VelocityX = reader.ReadSignedShort();
                VelocityY = reader.ReadSignedShort();
                VelocityZ = reader.ReadSignedShort();
            }

            public int Type { get; set; }
        }

        [PacketSubInfo(759, 772)]
        public sealed partial class V759_772 : SpawnEntityPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                EntityId = reader.ReadVarInt();
                ObjectUUID = reader.ReadUUID();
                Type = reader.ReadVarInt();
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
                Pitch = reader.ReadSignedByte();
                Yaw = reader.ReadSignedByte();
                HeadPitch = reader.ReadSignedByte();
                ObjectData = reader.ReadVarInt();
                VelocityX = reader.ReadSignedShort();
                VelocityY = reader.ReadSignedShort();
                VelocityZ = reader.ReadSignedShort();
            }

            public int Type { get; set; }
            public sbyte HeadPitch { get; set; }
        }

        [PacketSubInfo(773, 774)]
        public sealed partial class V774_774 : SpawnEntityPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                EntityId = reader.ReadVarInt();
                ObjectUUID = reader.ReadUUID();
                Type = reader.ReadVarInt();
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
                Velocity = reader.ReadLpVec3(protocolVersion);
                Pitch = reader.ReadSignedByte();
                Yaw = reader.ReadSignedByte();
                HeadPitch = reader.ReadSignedByte();
                ObjectData = reader.ReadVarInt();
            }

            public LpVec3 Velocity { get; set; }
            public int Type { get; set; }
            public sbyte HeadPitch { get; set; }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}