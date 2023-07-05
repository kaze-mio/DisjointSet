namespace DisjointSet
{
    public interface IDisjointSet
    {
        int Count { get; }

        int FindSet(int a);

        int GetRank(int a);

        bool IsInSameSet(int a, int b);

        void Union(int a, int b);

        void Clear();
    }
}
