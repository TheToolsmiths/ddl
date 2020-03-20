using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models
{
    public static class ListExtensions
    {
        public static IReadOnlyList<T> GetRange<T>(this IReadOnlyList<T> list, Range range)
        {
            (int offset, int length) = range.GetOffsetAndLength(list.Count);

            return list.Skip(offset).Take(length).ToList();
        }
    }
}
