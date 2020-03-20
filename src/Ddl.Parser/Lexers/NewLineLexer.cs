﻿using System;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    internal static class NewLineLexer
    {
        public static void HandleNewLinePhase(ref LexerSequenceReadState readState)
        {
            while (readState.HasCurrent)
            {
                // If next line is not LineFeed or CarriageReturn
                if (CharHelpers.IsNewLineChar(readState.CurrentChar) == false)
                {
                    // Move to Searching state
                    readState.MoveToState(LexerStatePhase.Searching);

                    // If there was a saved previous char
                    if (readState.TryGetFirstCharScratchMemory(out char firstScratchChar))
                    {
                        // And it was a carriage return
                        if (firstScratchChar == CharConstants.CarriageReturn)
                        {
                            // Assume as new line and increase line count
                            readState.NextLine();
                        }
                    }

                    return;
                }

                if (readState.CurrentChar == CharConstants.LineFeed)
                {
                    readState.NextLine();
                }
                else if (readState.CurrentChar == CharConstants.CarriageReturn)
                {
                    if (readState.TryGetFirstCharScratchMemory(out char firstScratchChar))
                    {
                        if (firstScratchChar == CharConstants.CarriageReturn)
                        {
                            readState.NextLine();
                        }
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

                var memory = readState.ClearAndGetStageScratchMemory(1);

                memory.Span[0] = readState.CurrentChar;

                readState.MoveNext();
            }
        }
    }
}
