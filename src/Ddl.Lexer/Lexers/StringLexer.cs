using System;

namespace TheToolsmiths.Ddl.Lexer.Lexers
{
    internal static class StringLexer
    {
        public static void HandleStringPhase(ref LexerSequenceReadState readState)
        {
            if (readState.HasStageScratchMemory == false)
            {
                if (readState.CurrentChar != CharConstants.DoubleQuotes)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    readState.MoveNext();
                }
            }

            var start = readState.CurrentIndex;
            var end = readState.CurrentIndex;

            while (readState.HasCurrent)
            {
                if (readState.CurrentChar == CharConstants.DoubleQuotes)
                {
                    var tempMemory = readState.GetWrittenStageScratchMemory();

                    // Create an identifier token with what we've read so far
                    end = readState.CurrentIndex;

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

                    var lexerToken = LexerToken.CreateStringToken(memory);

                    readState.EnqueueToken(lexerToken);

                    // Skip closing quotes and move next
                    readState.MoveNext();

                    // Default back to the Searching phase
                    readState.MoveToState(LexerStatePhase.Searching);

                    // Return
                    return;
                }

                if (readState.HasNext == false)
                {
                    end = readState.CurrentIndex.Next();
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

                if (readState.HasStageScratchMemory)
                {
                    throw new NotImplementedException();
                }

                var range = new Range(start, end);

                var identifierChars = readState.GetRange(range);

                readState.SetStageScratchMemory(identifierChars);

                readState.MoveNext();
            }
        }
    }
}
