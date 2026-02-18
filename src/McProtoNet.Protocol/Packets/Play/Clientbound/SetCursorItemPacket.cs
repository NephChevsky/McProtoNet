using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("SetCursorItem", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class SetCursorItemPacket : IServerPacket
    {
        public Slot? Contents { get; set; }

        [PacketSubInfo(768, 774)]
        public sealed partial class V768_774 : SetCursorItemPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                Contents = reader.ReadOptional((ref MinecraftPrimitiveReader r_0) => r_0.ReadSlot(protocolVersion));
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}