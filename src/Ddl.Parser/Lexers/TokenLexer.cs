using System;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    internal static class TokenLexer
    {
        public static void HandleTokenPhase(ref LexerSequenceReadState readState)
        {
            if (readState.TryGetFirstCharScratchMemory(out char firstChar) == false)
            {
                firstChar = readState.CurrentChar;
            }

            switch (firstChar)
            {
                case CharConstants.Comma:
                case CharConstants.Equal:
                case CharConstants.OpenScope:
                case CharConstants.CloseScope:
                    HandleSingleCharToken(ref readState);
                    return;

                case CharConstants.Slash:
                    HandleSlash(ref readState);
                    return;

                case CharConstants.Colon:
                    HandleColonToken(ref readState);
                    return;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void HandleSingleCharToken(ref LexerSequenceReadState readState)
        {
            var token = readState.CurrentChar switch
            {
                CharConstants.OpenScope => LexerToken.CreateOpenScopeToken(),
                CharConstants.CloseScope => LexerToken.CreateCloseScopeToken(),
                CharConstants.Comma => LexerToken.CreateListSeparatorToken(),
                CharConstants.Equal => LexerToken.CreateFieldInitializationToken(),
                _ => throw new ArgumentOutOfRangeException(nameof(readState.CurrentChar), readState.CurrentChar,
                    "Char is not valid single token")
            };

            readState.EnqueueToken(token);

            readState.MoveNext();

            readState.MoveToState(LexerStatePhase.Searching);
        }

        private static void HandleSlash(ref LexerSequenceReadState readState)
        {
            if (readState.GetWrittenStageScratchMemory().IsEmpty == false)
            {
                throw new NotImplementedException();
            }

            // If there is no next char available
            // Save current char and return
            if (readState.TryPeek(out char next) == false)
            {
                // If stream is completed Enqueue current char as token and return
                if (readState.IsCompleted)
                {
                    var token = LexerToken.CreateSlashToken();
                    readState.EnqueueToken(token);
                    readState.MoveNext();

                    return;
                }

                throw new NotImplementedException();

                return;
            }

            // If next char is also a slash
            if (next == CharConstants.Slash)
            {
                readState.MoveForCurrentAndNextChar();

                // Go to LineComment state
                readState.MoveToState(LexerStatePhase.LineComment);
                return;
            }

            // If next char is also token
            if (next == CharConstants.Asterisk)
            {
                // then MoveNext for current char
                readState.MoveNext();

                // MoveNext for next char
                readState.MoveNext();

                // Go to LineComment state
                readState.MoveToState(LexerStatePhase.BlockComment);
                return;
            }

            // If next char isn't colon,
            {
                // then enqueue value assignment token
                var token = LexerToken.CreateSlashToken();

                readState.EnqueueToken(token);
                readState.MoveNext();
            }
        }

        private static void HandleColonToken(ref LexerSequenceReadState readState)
        {
            char nextChar;

            // If there was a char in scratch memory
            if (readState.TryGetFirstCharScratchMemory(out char firstChar))
            {
                if (firstChar != CharConstants.Colon)
                {
                    throw new NotImplementedException();
                }

                nextChar = readState.CurrentChar;
            }
            // If there is no next char available
            // Save current char and return
            else if (readState.TryPeek(out nextChar) == false)
            {
                if (readState.IsCompleted)
                {
                    var token = LexerToken.CreateValueAssignmentToken();
                    readState.EnqueueToken(token);
                    readState.MoveNext();

                    return;
                }

                // Save current colon for scratch memory and return
                var memory = readState.ClearAndGetStageScratchMemory(1);
                memory.Span[0] = CharConstants.Colon;

                return;
            }

            // If next char is also token
            if (nextChar == CharConstants.Colon)
            {
                // then enqueue namespace separator token
                var token = LexerToken.CreateNamespaceSeparatorToken();
                readState.EnqueueToken(token);
                readState.MoveNext();

                // MoveNext for next char
                readState.MoveNext();
            }
            // If next char isn't colon,
            else
            {
                // then enqueue value assignment token
                var token = LexerToken.CreateValueAssignmentToken();
                readState.EnqueueToken(token);
                readState.MoveNext();
            }

            readState.MoveToState(LexerStatePhase.Searching);
        }
    }
}
