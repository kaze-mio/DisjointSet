namespace DisjointSet.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestDisjointSet()
        {
            for (int seed = 0; seed < 256; seed++)
            {
                TestDisjointset(seed, 256, UnionStrategy.None);
            }
        }

        [TestMethod]
        public void TestDisjointSetWithSize()
        {
            for (int seed = 0; seed < 256; seed++)
            {
                TestDisjointset(seed, 256, UnionStrategy.UnionBySize);
            }
        }

        [TestMethod]
        public void TestDisjointSetWithRank()
        {
            for (int seed = 0; seed < 256; seed++)
            {
                TestDisjointset(seed, 256, UnionStrategy.UnionByRank);
            }
        }

        private static List<int>[] CreateRandomSets(int count, Random rand)
        {
            int setCount = rand.Next(1, count + 1);
            List<int>[] setGroup = new List<int>[setCount];
            for (int i = 0; i < setCount; i++)
            {
                setGroup[i] = new List<int>();
            }
            for (int i = 0; i < count; i++)
            {
                int setIndex = rand.Next(0, setCount);
                setGroup[setIndex].Add(i);
            }
            return setGroup;
        }

        private static void TestDisjointset(int seed, int maxCount, UnionStrategy strategy)
        {
            Random rand = new Random(seed);
            int count = rand.Next(1, maxCount);
            int setCount = rand.Next(1, count);
            List<int>[] setGroup = CreateRandomSets(count, rand);
            DisjointSet disjointSet = new DisjointSet(count, strategy);

            foreach (var set in setGroup)
            {
                for (int i = 0; i < set.Count - 1; i++)
                {
                    disjointSet.Union(set[i], set[i + 1]);
                }
            }

            // Test number of non-empty sets
            int nonEmptySetCount = setGroup.Count((set) => set.Count > 0);
            Assert.AreEqual(nonEmptySetCount, disjointSet.GetSetCount());

            // Test connectivity
            foreach (var (setA, setB) in setGroup.SelectMany((set) => setGroup, (setA, setB) => (setA, setB)))
            {
                foreach (var (i, j) in setA.SelectMany((i) => setB, (i, j) => (i, j)))
                {
                    Assert.AreEqual(setA == setB, disjointSet.IsInSameSet(i, j));
                }
            }

            // Test size
            if (strategy == UnionStrategy.UnionBySize)
            {
                foreach (var (set, i) in setGroup.SelectMany((set) => set, (set, i) => (set, i)))
                {
                    Assert.AreEqual(set.Count, disjointSet.GetRank(i));
                }
            }
        }
    }
}
