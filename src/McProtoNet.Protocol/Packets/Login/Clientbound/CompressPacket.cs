using McProtoNet.Serialization;
using McProtoNet.Protocol;

namespace McProtoNet.Protocol.Packets.Login.Clientbound
{
    [PacketInfo("Compress", PacketState.Login, PacketDirection.Clientbound)]
    public abstract partial class CompressPacket : IServerPacket
    {
        public int Threshold { get; set; }

        [PacketSubInfo(340, 774)]
        public sealed partial class V340_774 : CompressPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                Threshold = reader.ReadVarInt();
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}