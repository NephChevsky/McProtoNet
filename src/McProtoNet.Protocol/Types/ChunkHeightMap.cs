namespace McProtoNet.Protocol.Types
{
    public struct ChunkHeightMap(int type, long[] data)
    {
        public int Type { get; set; } = type;
        public long[] Data { get; set; } = data;
    }
}
