using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> CopyDictionary<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            var newDictionary = new Dictionary<TKey, TValue>();

            foreach (var (key, value) in dictionary)
            {
                newDictionary.Add(key, value);
            }

            return newDictionary;
        }
    }
}
