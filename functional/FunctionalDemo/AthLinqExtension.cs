using System;
using System.Collections.Generic;

namespace FunctionalDemo.Linq
{
    public static class AthLinqExtension
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                Console.WriteLine("WHERE: {0}", item);
                if (predicate(item)) yield return item;
            }
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                Console.WriteLine("ANY: {0}", item);
                if (predicate(item)) return true;
            }
            return false;
        }

        public static bool Any<T>(this IEnumerable<T> source)
        {
            using (var e = source.GetEnumerator())
            {
                Console.WriteLine("ANY");
                if (e.MoveNext()) return true;
            }
            return false;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            int count = 0;
            using (var e = source.GetEnumerator())
            {
                checked
                {
                    while (e.MoveNext())
                    {
                        Console.WriteLine("COUNT: {0}", e.Current);
                        count++;
                    }
                }
            }
            return count;
        }

        public static IEnumerable<U> Select<T, U>(this IEnumerable<T> source, Func<T, U> selector)
        {
            foreach (var item in source)
            {
                Console.WriteLine("SELECT: {0}", item);
                yield return selector(item);
            }
        }
    }
}
