using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace IL.Tequila
{
    public static class EnumerableExtensions
    {
        public static bool AllNonAlloc<TSource, TState>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (!predicate(source, state))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AnyNonAlloc<TSource, TState>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (predicate(source, state))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<TResult> SelectNonAlloc<TSource, TState, TResult>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, TResult> selector)
        {
            foreach (var source in enumerable)
            {
                yield return selector(source, state);
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(static _ => Random.value);
        }

        public static IEnumerable<TSource> WhereNonAlloc<TSource, TState>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (predicate(source, state))
                {
                    yield return source;
                }
            }
        }
    }
}
