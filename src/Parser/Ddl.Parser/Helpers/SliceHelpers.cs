using System;
using System.Buffers;

namespace TheToolsmiths.Ddl.Parser.Helpers
{
    public static class SliceHelpers
    {
        public static ReadOnlySequence<T> SliceClamp<T>(this ReadOnlySequence<T> sequence, long maxLength)
        {
            long length = Math.Clamp(sequence.Length, 0, maxLength);

            if (length == 0)
            {
                return ReadOnlySequence<T>.Empty;
            }

            return sequence.Slice(0, length);
        }
    }
}
