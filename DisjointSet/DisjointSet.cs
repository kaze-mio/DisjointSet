namespace DisjointSet
{
    public class DisjointSet : IDisjointSet
    {
        private int m_count;

        private UnionStrategy m_strategy;

        private int[] m_parent;

        private int[] m_rank;

        public int Count => m_count;

        public UnionStrategy Strategy => m_strategy;

        public DisjointSet(int count) : this(count, UnionStrategy.None)
        {
        }

        public DisjointSet(int count, UnionStrategy strategy)
        {
            m_count = count;
            m_strategy = strategy;
            m_parent = new int[count];
            m_rank = new int[count];
            for (int i = 0; i < count; i++)
            {
                m_parent[i] = i;
                m_rank[i] = 1;
            }
        }

        public int FindSet(int a)
        {
            int p = m_parent[a];
            return (a == p) ? p : (m_parent[a] = FindSet(p));
        }

        public int GetRank(int a)
        {
            return m_rank[FindSet(a)];
        }

        public bool IsInSameSet(int a, int b)
        {
            return FindSet(a) == FindSet(b);
        }

        public void Union(int a, int b)
        {
            int pA = FindSet(a);
            int pB = FindSet(b);

            if (pA == pB)
            {
                return;
            }

            switch (m_strategy)
            {
                case UnionStrategy.UnionBySize:
                    if (m_rank[pA] < m_rank[pB])
                        (pA, pB) = (pB, pA);
                    m_parent[pB] = pA;
                    m_rank[pA] += m_rank[pB];
                    break;

                case UnionStrategy.UnionByRank:
                    if (m_rank[pA] < m_rank[pB])
                        (pA, pB) = (pB, pA);
                    m_parent[pB] = pA;
                    if (m_rank[pA] == m_rank[pB])
                        m_rank[pA]++;
                    break;

                default:
                    m_parent[pB] = pA;
                    break;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < m_count; i++)
            {
                m_parent[i] = i;
                m_rank[i] = 1;
            }
        }
    }
}
