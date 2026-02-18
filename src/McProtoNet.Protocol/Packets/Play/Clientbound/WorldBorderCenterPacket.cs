using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("WorldBorderCenter", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class WorldBorderCenterPacket : IServerPacket
    {
        public double X { get; set; }
        public double Z { get; set; }

        [PacketSubInfo(755, 774)]
        public sealed partial class V755_774 : WorldBorderCenterPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                X = reader.ReadDouble();
                Z = reader.ReadDouble();
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}