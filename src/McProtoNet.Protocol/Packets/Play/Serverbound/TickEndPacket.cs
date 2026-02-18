using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Serverbound
{
    [PacketInfo("TickEnd", PacketState.Play, PacketDirection.Serverbound)]
    public partial class TickEndPacket : IClientPacket
    {
        [PacketSubInfo(768, 774)]
        public sealed partial class V768_774 : TickEndPacket
        {
            public override void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
            {
                SerializeInternal(ref writer, protocolVersion);
            }

            internal static void SerializeInternal(ref MinecraftPrimitiveWriter writer, int protocolVersion)
            {
            }
        }

        public virtual void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
        {
            if (V768_774.IsSupportedVersionStatic(protocolVersion))
                V768_774.SerializeInternal(ref writer, protocolVersion);
            else
                throw new ProtocolNotSupportException(nameof(ClientPlayPacket.TickEnd), protocolVersion);
        }
    }
}