namespace DisjointSet
{
    public interface IDisjointSetNode<TNode>
    {
        public TNode Parent { get; set; }

        public int Rank { get; set; }
    }
}
