using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("EnterCombatEvent", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class EnterCombatEventPacket : IServerPacket
    {
        [PacketSubInfo(755, 774)]
        public sealed partial class V755_774 : EnterCombatEventPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}