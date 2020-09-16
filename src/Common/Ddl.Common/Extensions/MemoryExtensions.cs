using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Extensions
{
    public static class MemoryExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, ReadOnlyMemory<T> source)
        {
            foreach (var item in source.Span)
            {
                collection.Add(item);
            }
        }
    }
}
