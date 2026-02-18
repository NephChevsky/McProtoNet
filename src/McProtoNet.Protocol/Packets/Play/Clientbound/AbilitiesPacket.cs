using McProtoNet.Protocol;
using McProtoNet.NBT;
using McProtoNet.Serialization;
using System;

namespace McProtoNet.Protocol.Packets.Play.Clientbound
{
    [PacketInfo("Abilities", PacketState.Play, PacketDirection.Clientbound)]
    public abstract partial class AbilitiesPacket : IServerPacket
    {
        public sbyte Flags { get; set; }
        public float FlyingSpeed { get; set; }
        public float WalkingSpeed { get; set; }

        [PacketSubInfo(340, 774)]
        internal sealed partial class V340_774 : AbilitiesPacket
        {
            public override void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion)
            {
                Flags = reader.ReadSignedByte();
                FlyingSpeed = reader.ReadFloat();
                WalkingSpeed = reader.ReadFloat();
            }
        }

        public abstract void Deserialize(ref MinecraftPrimitiveReader reader, int protocolVersion);
    }
}