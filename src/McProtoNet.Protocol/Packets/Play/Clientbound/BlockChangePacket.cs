using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("BlockChange", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class BlockChangePacket : IServerPacket
    {
        public Position Location { get; set; }
        public int Type { get; set; }

        [PacketSubInfo(340, 774)]
        public sealed partial class V340_774 : BlockChangePacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                Location = reader.ReadPosition(protocolVersion);
                Type = reader.ReadVarInt();
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}