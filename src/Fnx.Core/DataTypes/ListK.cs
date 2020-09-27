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
        public static List<T> Fix<T>(this IKind<ListF, T> self) => ((ListK<T>) self).List;

        public static IKind<ListF, T> ToKind<T>(this List<T> self) => new ListK<T>(self);
    }
}