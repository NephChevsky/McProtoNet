using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Serverbound
{
    [PacketInfo("Spectate", PacketState.Play, PacketDirection.Serverbound)]
    public partial class SpectatePacket : IClientPacket
    {
        public Guid Target { get; set; }

        [PacketSubInfo(340, 774)]
        internal sealed partial class V340_774 : SpectatePacket
        {
            public override void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
            {
                SerializeInternal(ref writer, protocolVersion, Target);
            }

            internal static void SerializeInternal(ref MinecraftPrimitiveWriter writer, int protocolVersion,
                Guid target)
            {
                writer.WriteUUID(target);
            }
        }

        public virtual void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
        {
            if (V340_774.IsSupportedVersionStatic(protocolVersion))
                V340_774.SerializeInternal(ref writer, protocolVersion, Target);
            else
                throw new ProtocolNotSupportException(nameof(ClientPlayPacket.Spectate), protocolVersion);
        }
    }
}