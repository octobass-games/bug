using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtension
{
    public static T PickRandom<T>(this IEnumerable<T> source)
    {
        return source.PickRandom(1).Single();
    }

    public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
    {
        return source.Shuffle().Take(count);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(x => Guid.NewGuid());
    }

    public static int NextIndex<T>(this List<T> source, int currentIndex)
    {
        if (currentIndex < 0) return 0;

        return (currentIndex + 1) % (source.Count);
    }
}