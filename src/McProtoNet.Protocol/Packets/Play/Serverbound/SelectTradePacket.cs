using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Serverbound
{
    [PacketInfo("SelectTrade", PacketState.Play, PacketDirection.Serverbound)]
    public partial class SelectTradePacket : IClientPacket
    {
        public int Slot { get; set; }

        [PacketSubInfo(393, 774)]
        public sealed partial class V393_774 : SelectTradePacket
        {
            public override void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
            {
                SerializeInternal(ref writer, protocolVersion, Slot);
            }

            internal static void SerializeInternal(ref MinecraftPrimitiveWriter writer, int protocolVersion, int slot)
            {
                writer.WriteVarInt(slot);
            }
        }

        public virtual void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
        {
            if (V393_774.IsSupportedVersionStatic(protocolVersion))
                V393_774.SerializeInternal(ref writer, protocolVersion, Slot);
            else
                throw new ProtocolNotSupportException(nameof(ClientPlayPacket.SelectTrade), protocolVersion);
        }
    }
}