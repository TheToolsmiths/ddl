﻿namespace TheToolsmiths.Ddl.Lexer.Lexers
{
    internal static class CommentLexer
    {
        public static void HandleLineComment(ref LexerSequenceReadState readState)
        {
            while (readState.HasCurrent)
            {
                // If current char is line ending char
                if (CharHelpers.IsNewLineChar(readState.CurrentChar))
                {
                    readState.MoveToState(LexerStatePhase.Searching);

                    return;
                }

                readState.MoveNext();
            }
        }

        public static void HandleBlockComment(ref LexerSequenceReadState readState)
        {
            if (readState.TryGetFirstCharScratchMemory(out char first) == false)
            {
                first = readState.CurrentChar;
            }

            while (readState.HasCurrent)
            {
                // If current char is *
                if (first == CharConstants.Asterisk)
                {
                    // But we don't have a next char
                    if (readState.TryPeek(out char next) == false)
                    {
                        readState.ClearAndSetCharOnStageScratchMemory(CharConstants.Asterisk);

                        readState.MoveNext();

                        return;
                    }

                    // If there is a next char and it is a slash
                    if (next == CharConstants.Slash)
                    {
                        // Stop reading comment block
                        readState.MoveToState(LexerStatePhase.Searching);

                        readState.MoveForCurrentAndNextChar();

                        return;
                    }
                }

                readState.MoveNext();

                if (readState.HasCurrent)
                {
                    first = readState.CurrentChar;
                }
            }
        }
    }
}