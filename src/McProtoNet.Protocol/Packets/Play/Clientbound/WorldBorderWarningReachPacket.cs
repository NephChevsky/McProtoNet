using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("WorldBorderWarningReach", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class WorldBorderWarningReachPacket : IServerPacket
    {
        public int WarningBlocks { get; set; }

        [PacketSubInfo(755, 774)]
        public sealed partial class V755_774 : WorldBorderWarningReachPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                WarningBlocks = reader.ReadVarInt();
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}