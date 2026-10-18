using System.Diagnostics;

namespace RefactoringLab.Part03.BlockedUsers;

public static class BlockedUserChecker
{
    public static int CountBlocked(List<int> blockedIds, int[] requestIds)
    {
        var blockedSet = new HashSet<int>(blockedIds);
        return requestIds.Count(id => blockedSet.Contains(id));
    }

    public static List<int> BuildBlockedIds(int count)
    {
        var list = new List<int>(count);
        for (var i = 0; i < count; i++)
            list.Add(i);
        return list;
    }

    public static int[] BuildRequestIds(int count, int maxId, int seed = 42)
    {
        var rnd = new Random(seed);
        var ids = new int[count];
        for (var i = 0; i < count; i++)
            ids[i] = rnd.Next(maxId);
        return ids;
    }

    public static long MeasureMs(List<int> blockedIds, int[] requestIds, out int found)
    {
        var sw = Stopwatch.StartNew();
        found = CountBlocked(blockedIds, requestIds);
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
