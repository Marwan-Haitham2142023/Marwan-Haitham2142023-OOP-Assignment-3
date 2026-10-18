# Collections/Answers.md

## IReadOnlyDictionary and SortedDictionary

### What is `IReadOnlyDictionary<TKey, TValue>`?

It is an interface for a collection that holds key-value pairs. You can only read from it. You can find a value using its key, check if a key is present, go through all the keys and values, and find out how many items are in the collection. You cannot add, remove, or change anything. It is a read-only version.

A regular `Dictionary` can act as an `IReadOnlyDictionary` because `Dictionary` has this interface. The interface simply stops the user from changing the data.

### What is `SortedDictionary<TKey, TValue>`?

It is a class that keeps key-value pairs sorted by the key. Inside it uses a structure called a tree — a red-black tree — which keeps everything in order after each addition or removal. Because it is a tree, each search, insertion, and deletion takes O(log n) time. When you go through the items, they are always in order. Unlike a `Dictionary`, which has no order at all.

### How is `IReadOnlyDictionary` different from `Dictionary`?

The main difference is whether you can change the data or not.

`Dictionary` allows you to add, remove, clear, and update values using the indexer.

`IReadOnlyDictionary` only allows reading: `TryGetValue`, `ContainsKey`, the indexer for reading, `Keys`, `Values`, and `Count`.

A `Dictionary` is a `IReadOnlyDictionary` (it has this interface). The reverse is not true. The interface is a way to show only the read-only part of the data.

### Why would a public method return `IReadOnlyDictionary` instead of a `Dictionary`?

There are three reasons.

1. It tells the user "do not change this." If a method returns a `Dictionary`, the user might think it is safe to add or remove items. If the method is sharing data, this can break things. Returning the read-only version stops this from happening. The compiler will not let it happen.

2. It hides the type. The user does not need to know it is a `Dictionary`. The next day the method could return a `SortedDictionary` instead and the user would not notice.

3. It keeps the data safe. The method keeps its changeable dictionary and gives out only a read-only version. The user can see the data but cannot change the method's internal data.

In short: `IReadOnlyDictionary` is a promise. "Here is the data — look at it but do not touch it." A `Dictionary` return type makes no promise.

### How is `SortedDictionary` different from `Dictionary` in ordering and lookup speed?

`Dictionary` has no order. Items come out in whatever order the hash table decides. `SortedDictionary` is always sorted by key, and looping always gives items in order.

`Dictionary` lookup speed is O(1) on average — a single step in a hash table. `SortedDictionary` lookup speed is O(log n) — it moves down a tree.

`Dictionary` add/remove is O(1) on average. `SortedDictionary` add/remove is O(log n).

`Dictionary` usually uses less memory. `SortedDictionary` usually uses more because tree nodes have extra pointers.

In words: `Dictionary` is faster for looking up one key but has no order. `SortedDictionary` is slower per operation, but the items are always in order.

### When would you choose `SortedDictionary`?

Choose it when you need the items in order by key, and that order is important for the job — not just a nice-to-have.

Situations:

You need to loop in key order. For example, a leaderboard sorted by score, or events sorted by time. With a `Dictionary` you would have to sort it each time you loop, which takes O(n log n) each time.

You need ranges. "Give me all keys from X to Y." A sorted structure makes this easy; a hash table cannot do it.

You often need the largest key. A `SortedDictionary` finds it quickly; a `Dictionary` has to check everything.

You add and remove a lot, and it must stay sorted. `SortedDictionary` keeps the order as you go, paying O(log n) each time. If you used a `Dictionary` and sorted it by hand every time, you would pay O(n log n) again and again.

Do not choose it when:

You only look up keys and never care about order. `Dictionary` is faster and uses less memory.

You build it once, never change it, and only need the view once at the end. Sorting once is cheaper than paying O(log n) on every insert.

Simple rule: if you find yourself writing `dictionary.OrderBy(x => x.Key)` more than once, switch to `SortedDictionary`. If you never write it, stick with `Dictionary`.

## Scenario Answers

### S1 Find a student by national ID — thousands of times a day.

**Answer: Dictionary**

Because a national ID is a unique key, and `Dictionary` provides O(1) average lookup time, which is fast enough to handle thousands of queries per day.

### S2 Keep the tags of a course. The same tag must never be stored twice.

**Answer: HashSet**

Because `HashSet` only stores unique elements, duplicate tags will be automatically rejected, which exactly meets the "never stored twice" requirement.

### S3 Keep a student's grades in the order they were entered. The same grade can appear more than once.

**Answer: List**

Because `List` preserves insertion order and allows duplicate elements, which matches the requirement of "keeping entry order" and "the same grade can appear multiple times."

### S4 A public method returns the course price list. Callers can read prices but must not add or change any.

**Answer: IReadOnlyDictionary**

Because this interface only exposes read operations, callers can check prices but cannot add or modify data, which meets the safety requirement.

### S5 A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.

**Answer: SortedDictionary**

Because `SortedDictionary` always keeps key-value pairs sorted by key, and the lookup/insertion time complexity is O(log n), making it suitable for scenarios that need to stay ordered while frequently adding new elements.

### S6 A method returns results that the caller only loops over once — and may stop early.

**Answer: IEnumerable**

Because `IEnumerable` supports deferred execution, the caller can stop iterating at any time without forcing the entire result set to be generated at once, saving memory and computation.