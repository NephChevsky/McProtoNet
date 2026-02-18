using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Serverbound
{
    [PacketInfo("DebugSampleSubscription", PacketState.Play, PacketDirection.Serverbound)]
    public partial class DebugSampleSubscriptionPacket : IClientPacket
    {
        public int Type { get; set; }

        [PacketSubInfo(766, 774)]
        public sealed partial class V766_774 : DebugSampleSubscriptionPacket
        {
            public override void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
            {
                SerializeInternal(ref writer, protocolVersion, Type);
            }

            internal static void SerializeInternal(ref MinecraftPrimitiveWriter writer, int protocolVersion, int type)
            {
                writer.WriteVarInt(type);
            }
        }

        public virtual void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
        {
            if (V766_774.IsSupportedVersionStatic(protocolVersion))
                V766_774.SerializeInternal(ref writer, protocolVersion, Type);
            else
                throw new ProtocolNotSupportException(nameof(ClientPlayPacket.DebugSampleSubscription),
                    protocolVersion);
        }
    }
}