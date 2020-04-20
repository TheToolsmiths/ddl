namespace TheToolsmiths.Ddl.Lexer.Lexers
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
            char next;
            if (readState.TryGetFirstCharScratchMemory(out char first))
            {
                next = readState.CurrentChar;
            }
            else
            {
                if (readState.TryPeek(out next) == false)
                {
                    readState.ClearAndSetCharOnStageScratchMemory(readState.CurrentChar);

                    readState.MoveNext();

                    return;
                }

                first = readState.CurrentChar;
            }

            while (readState.HasCurrent)
            {
                // If current char is *
                // If there is a next char and it is a slash
                if (first == CharConstants.Asterisk && next == CharConstants.Slash)
                {
                    // Stop reading comment block
                    readState.MoveToState(LexerStatePhase.Searching);

                    readState.MoveNext();

                    return;
                }

                first = readState.CurrentChar;

                // But we don't have a next char
                if (readState.TryPeek(out next) == false)
                {
                    readState.ClearAndSetCharOnStageScratchMemory(readState.CurrentChar);

                    readState.MoveNext();

                    return;
                }

                readState.MoveNext();
            }

            readState.ClearAndSetCharOnStageScratchMemory(next);
        }
    }
}
