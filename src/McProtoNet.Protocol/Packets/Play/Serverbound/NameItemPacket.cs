using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Serverbound
{
    [PacketInfo("NameItem", PacketState.Play, PacketDirection.Serverbound)]
    public partial class NameItemPacket : IClientPacket
    {
        public string Name { get; set; }

        [PacketSubInfo(393, 774)]
        public sealed partial class V393_774 : NameItemPacket
        {
            public override void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
            {
                SerializeInternal(ref writer, protocolVersion, Name);
            }

            internal static void SerializeInternal(ref MinecraftPrimitiveWriter writer, int protocolVersion,
                string name)
            {
                writer.WriteString(name);
            }
        }

        public virtual void Serialize(ref MinecraftPrimitiveWriter writer, int protocolVersion)
        {
            if (V393_774.IsSupportedVersionStatic(protocolVersion))
                V393_774.SerializeInternal(ref writer, protocolVersion, Name);
            else
                throw new ProtocolNotSupportException(nameof(ClientPlayPacket.NameItem), protocolVersion);
        }
    }
}