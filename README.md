# DisjointSet

A disjoint-set data structure implementation for c-sharp.



## Types

```c#
// disjoint-set with memory storage
public interface IDisjointSet { ... }
public class DisjointSet : IDisjointSet { ... }
public static class DisjointSetExtensions { ... }

// disjoint-set with node
public class IDisjointSetNode<TNode> { ... }
public class DisjointSetNode<TValue> : IDisjointSetNode<DisjointSetNode<TValue>> { ... }
public static class DisjointSetNodeExtensions { ... }

// others
public enum UnionStrategy { ... }    

```



## Usage

```c#
var disjointSet = new DisjointSet(3, UnionStrategy.UnionBySize);

disjointSet.Union(0, 1);

bool b0 = disjointSet.IsInSameSet(0, 1); // True
bool b1 = disjointSet.IsInSameSet(0, 2); // False

int n0 = disjointSet.GetRank(0); // 2
int n1 = disjointSet.GetRank(1); // 2
int n2 = disjointSet.GetRank(2); // 1

int setCount = disjointSet.GetSetCount(); // 2
var setGroup = disjointSet.GetSetGroup(); // [[0, 1], [2]]
```


