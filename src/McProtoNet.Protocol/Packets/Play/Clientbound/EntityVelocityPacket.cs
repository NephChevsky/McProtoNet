using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;
using McProtoNet.Protocol.Types;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("EntityVelocity", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class EntityVelocityPacket : IServerPacket
    {
        public int EntityId { get; set; }
        public short VelocityX { get; set; }
        public short VelocityY { get; set; }
        public short VelocityZ { get; set; }

        [PacketSubInfo(340, 772)]
        internal sealed partial class V340_772 : EntityVelocityPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                EntityId = reader.ReadVarInt();
                VelocityX = reader.ReadSignedShort();
                VelocityY = reader.ReadSignedShort();
                VelocityZ = reader.ReadSignedShort();
            }
        }

        [PacketSubInfo(773, 774)]
        internal sealed partial class V773_774 : EntityVelocityPacket
        {
            public LpVec3 Velocity { get; set; }
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                EntityId = reader.ReadVarInt();
                Velocity = reader.ReadLpVec3(protocolVersion);
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}