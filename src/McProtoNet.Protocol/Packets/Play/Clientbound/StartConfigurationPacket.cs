using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("StartConfiguration", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class StartConfigurationPacket : IServerPacket
    {
        [PacketSubInfo(764, 774)]
        public sealed partial class V764_774 : StartConfigurationPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}