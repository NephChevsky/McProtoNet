using McProtoNet.Serialization;

namespace McProtoNet.Protocol.Packets.Configuration.Clientbound;

[PacketInfo("Ping", PacketState.Configuration, PacketDirection.Clientbound)]
public abstract partial class PingPacket : IServerPacket
{
    public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);

    [PacketSubInfo(764, 774)]
    public sealed partial class V764_774 : PingPacket
    {
        public int Id { get; set; }

        public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
        {
            Id = reader.ReadSignedInt();
        }
    }
}