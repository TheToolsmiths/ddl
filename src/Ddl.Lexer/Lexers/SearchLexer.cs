namespace TheToolsmiths.Ddl.Lexer.Lexers
{
    internal static class SearchLexer
    {
        public static void HandleSearchingPhase(ref LexerSequenceReadState readState)
        {
            void HandleNewLine(ref LexerSequenceReadState refState)
            {
                refState.MoveToState(LexerStatePhase.NewLine);
            }

            void HandleNonWhiteSpaceChar(ref LexerSequenceReadState refState)
            {
                if (CharHelpers.IsIdentifierStart(refState.CurrentChar))
                {
                    refState.MoveToState(LexerStatePhase.Identifier);
                    return;
                }

                if (CharHelpers.IsNumberStart(refState.CurrentChar))
                {
                    refState.MoveToState(LexerStatePhase.Number);
                    return;
                }

                if (refState.CurrentChar == CharConstants.DoubleQuotes)
                {
                    refState.MoveToState(LexerStatePhase.String);
                    return;
                }

                refState.MoveToState(LexerStatePhase.Token);
            }

            while (readState.HasCurrent)
            {
                if (CharHelpers.IsNewLineChar(readState.CurrentChar))
                {
                    HandleNewLine(ref readState);
                    return;
                }

                if (char.IsWhiteSpace(readState.CurrentChar) == false)
                {
                    HandleNonWhiteSpaceChar(ref readState);
                    return;
                }

                readState.MoveNext();
            }
        }
    }
}
