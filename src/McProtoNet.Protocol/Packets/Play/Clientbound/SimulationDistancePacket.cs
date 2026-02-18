using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("SimulationDistance", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class SimulationDistancePacket : IServerPacket
    {
        public int Distance { get; set; }

        [PacketSubInfo(757, 774)]
        public sealed partial class V757_774 : SimulationDistancePacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                Distance = reader.ReadVarInt();
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}