using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Containers
{
    public class CharSpanKeyedMap<TItem> : IEnumerable<KeyValuePair<string, TItem>>
    {
        private readonly List<KeyValuePair<string, TItem>> entries;

        public CharSpanKeyedMap()
        {
            this.entries = new List<KeyValuePair<string, TItem>>();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(in ReadOnlySpan<char> key)
        {
            foreach ((string entryKey, var _) in this.entries)
            {
                if (entryKey == key)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(in ReadOnlySpan<char> key)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, TItem value)
        {
            if (this.Contains(key))
            {
                throw new ArgumentException(nameof(key));
            }

            var kvp = new KeyValuePair<string, TItem>(key, value);

            this.entries.Add(kvp);
        }

        public bool TryGetValue(in ReadOnlySpan<char> key, out TItem value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(in ReadOnlyMemory<char> key, [NotNullWhen(true)] out TItem value)
        {
            foreach ((string entryKey, var entryItem) in this.entries)
            {
                if (key.Span.SequenceEqual(entryKey))
                {
                    value = entryItem;
                    return true;
                }
            }

            value = default!;
            return false;
        }

        public IEnumerator<KeyValuePair<string, TItem>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
