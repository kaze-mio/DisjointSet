namespace DisjointSet
{
    public class DisjointSetNode<TValue> : IDisjointSetNode<DisjointSetNode<TValue>>
    {
        public DisjointSetNode<TValue> Parent { get; set; }

        public TValue Value { get; set; }

        public int Rank { get; set; }

        public DisjointSetNode(TValue value)
        {
            Parent = this;
            Value = value;
            Rank = 1;
        }
    }
}
