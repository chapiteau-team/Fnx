using System;
using System.Collections.Generic;
using Fnx.Core.Types;

namespace Fnx.Core.DataTypes
{
    public readonly struct ListF
    {
    }

    public class ListK<T> : IKind<ListF, T>
    {
        public List<T> List { get; }

        public ListK(List<T> list)
        {
            List = list;
        }
    }

    public static class List
    {
        public static List<TResult> Map<T, TResult>(this List<T> self, Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            var count = self.Count;
            var result = new List<TResult>(count);

            for (var i = 0; i < count; i++)
            {
                result.Add(map(self[i]));
            }

            return result;
        }

        public static List<TResult> FlatMap<T, TResult>(this List<T> self, Func<T, List<TResult>> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            var count = self.Count;
            var buffer = new List<List<TResult>>(count);
            var capacity = 0;
            for (var i = 0; i < count; i++)
            {
                var list = map(self[i]);
                capacity += list.Count;
                buffer.Add(list);
            }

            var result = new List<TResult>(capacity);
            for (var i = 0; i < count; i++)
            {
                result.AddRange(buffer[i]);
            }

            return result;
        }


        public static List<T> Fix<T>(this IKind<ListF, T> self) => ((ListK<T>) self).List;

        public static IKind<ListF, T> ToKind<T>(this List<T> self) => new ListK<T>(self);
    }
}