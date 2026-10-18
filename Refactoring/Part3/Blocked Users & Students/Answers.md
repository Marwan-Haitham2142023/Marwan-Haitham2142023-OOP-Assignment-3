

**Original implementation:**

```csharp
public static int CountBlocked(List<int> blockedIds, int[] requestIds)
{
    var blocked = 0;
    foreach (var id in requestIds) => O(n) scan
    {
        if (blockedIds.Contains(id))   // List<int>.Contains = O(n) scan
            blocked++;
    }
    return blocked;
}
```
So the time complexity of the original implementation is O(m * n), where m is the length of `requestIds` and n is the length of `blockedIds`.
This is because for each request ID, we are performing a linear scan through the `blockedIds` list to check for containment.