namespace DisjointSet
{
    public static class DisjointSetNodeExtensions
    {
        public static T FindSet<T>(this T self) where T : IDisjointSetNode<T>
        {
            return self.Equals(self.Parent) ? self : (self.Parent = FindSet(self.Parent));
        }

        public static bool IsInSameSet<T>(this T self, T other) where T : IDisjointSetNode<T>
        {
            return FindSet(self).Equals(FindSet(other));
        }

        public static void Union<T>(this T self, T other, UnionStrategy strategy) where T : IDisjointSetNode<T>
        {
            T pA = FindSet(self);
            T pB = FindSet(other);

            switch (strategy)
            {
                case UnionStrategy.UnionBySize:
                    if (pA.Rank < pB.Rank)
                        (pA, pB) = (pB, pA);
                    pB.Parent = pA;
                    pA.Rank += pB.Rank;
                    break;

                case UnionStrategy.UnionByRank:
                    if (pA.Rank < pB.Rank)
                        (pA, pB) = (pB, pA);
                    pB.Parent = pA;
                    if (pA.Rank == pB.Rank)
                        pA.Rank++;
                    break;

                default:
                    pB.Parent = pA;
                    break;
            }
        }
    }
}
