using System;
using System.Collections.Generic;

namespace DisjointSet
{
    public static class DisjointSetExtensions
    {
        public static int GetSetCount(this IDisjointSet disjointSet)
        {
            int count = disjointSet.Count;
            int setCount = 0;

            for (int i = 0; i < count; i++)
            {
                if (i == disjointSet.FindSet(i))
                {
                    setCount++;
                }
            }

            return setCount;
        }

        public static (int, int[]) GetSetIndices(this IDisjointSet disjointSet)
        {
            int count = disjointSet.Count;
            int setCount = 0;
            int[] setIndices = new int[count];
            Array.Fill(setIndices, -1);

            for (int i = 0; i < count; i++)
            {
                int parent = disjointSet.FindSet(i);
                int index = setIndices[parent];
                if (index == -1)
                {
                    index = setCount++;
                    setIndices[parent] = index;
                }
                setIndices[i] = index;
            }

            return (setCount, setIndices);
        }

        public static IReadOnlyCollection<List<int>> GetSetGroup(this IDisjointSet disjointSet)
        {
            int count = disjointSet.Count;
            Dictionary<int, List<int>> setGroup = new Dictionary<int, List<int>>();

            for (int i = 0; i < count; i++)
            {
                int parent = disjointSet.FindSet(i);
                if (!setGroup.TryGetValue(parent, out var set))
                {
                    set = new List<int>();
                    setGroup.Add(parent, set);
                }
                set.Add(i);
            }

            return setGroup.Values;
        }
    }
}
