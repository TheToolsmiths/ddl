using System;

namespace TheToolsmiths.Ddl.Lexer.Lexers
{
    internal static class NumberLexer
    {
        public static void HandleNumberPhase(ref LexerSequenceReadState readState)
        {
            var start = readState.CurrentIndex;

            while (readState.HasCurrent)
            {
                // If we found a non identifier char
                if (CharHelpers.IsValidNumberChar(readState.CurrentChar) == false)
                {
                    var tempMemory = readState.GetWrittenStageScratchMemory();

                    // Create an identifier token with what we've read so far
                    var end = readState.CurrentIndex;

                    var range = new Range(start, end);

                    var identifierChars = readState.GetRange(range);

                    int totalLength = tempMemory.Length + identifierChars.Length;

                    var memory = readState.GetIdentifierMemory(totalLength);

                    if (tempMemory.IsEmpty == false)
                    {
                        tempMemory.Span.CopyTo(memory.Span);
                    }

                    var offset = memory.Span.Slice(tempMemory.Length);

                    identifierChars.CopyTo(offset);

                    var lexerToken = LexerToken.CreateNumberToken(memory);

                    readState.EnqueueToken(lexerToken);

                    // Default back to the Searching phase
                    readState.MoveToState(LexerStatePhase.Searching);

                    // Return
                    return;
                }

                if (readState.HasNext == false)
                {
                    break;
                }

                readState.MoveNext();
            }

            // If we dropped out of the loop its because theres nothing else to read,
            // but we havent finished reading the token.
            {
                if (readState.IsCompleted)
                {
                    throw new NotImplementedException();
                }

                var end = readState.CurrentIndex.Next();

                var range = new Range(start, end);

                var identifierChars = readState.GetRange(range);

                readState.SetStageScratchMemory(identifierChars);

                readState.MoveNext();
            }
        }
    }
}
