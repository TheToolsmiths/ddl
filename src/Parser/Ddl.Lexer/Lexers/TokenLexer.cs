using System;
using System.Collections;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Lexer.Lexers
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
                case CharConstants.OpenScope:
                case CharConstants.CloseScope:
                case CharConstants.OpenAttribute:
                case CharConstants.CloseAttribute:
                case CharConstants.OpenParentheses:
                case CharConstants.CloseParentheses:
                case CharConstants.OpenGenerics:
                case CharConstants.CloseGenerics:
                case CharConstants.Semicolon:
                case CharConstants.Asterisk:
                    HandleSingleCharToken(ref readState);
                    return;

                case CharConstants.Slash:
                    HandleSlash(ref readState);
                    return;

                case CharConstants.And:
                    HandleAndToken(ref readState);
                    return;

                case CharConstants.Or:
                    HandleOrToken(ref readState);
                    return;

                case CharConstants.Colon:
                    HandleColonToken(ref readState);
                    return;

                case CharConstants.Not:
                    HandleNotToken(ref readState);
                    return;

                case CharConstants.Equal:
                    HandleEqualToken(ref readState);
                    return;

                default:
                    throw new ArgumentOutOfRangeException(nameof(firstChar), firstChar, "Unexpected value on switch");
            }
        }

        private static void HandleSingleCharToken(ref LexerSequenceReadState readState)
        {
            var token = readState.CurrentChar switch
            {
                CharConstants.OpenScope => LexerToken.CreateOpenScopeToken(),
                CharConstants.CloseScope => LexerToken.CreateCloseScopeToken(),
                CharConstants.OpenAttribute => LexerToken.CreateOpenAttributeToken(),
                CharConstants.CloseAttribute => LexerToken.CreateCloseAttributeToken(),
                CharConstants.OpenParentheses => LexerToken.CreateOpenParenthesesToken(),
                CharConstants.CloseParentheses => LexerToken.CreateCloseParenthesesToken(),
                CharConstants.OpenGenerics => LexerToken.CreateOpenGenericsToken(),
                CharConstants.CloseGenerics => LexerToken.CreateCloseGenericsToken(),
                CharConstants.Comma => LexerToken.CreateListSeparatorToken(),
                CharConstants.Semicolon => LexerToken.CreateEndStatementToken(),
                CharConstants.Asterisk => LexerToken.CreateAsteriskToken(),
                _ => throw new ArgumentOutOfRangeException(nameof(readState.CurrentChar), readState.CurrentChar,
                    "Char is not valid single token")
            };

            readState.EnqueueToken(token);

            readState.MoveNext();

            readState.MoveToState(LexerStatePhase.Searching);
        }

        private static void HandleSlash(ref LexerSequenceReadState readState)
        {
            char next;

            if (readState.TryGetFirstCharScratchMemory(out char _) == false)
            {
                // If there is no next char available
                // Save current char and return
                if (readState.TryPeek(out next) == false)
                {
                    // If stream is completed Enqueue current char as token and return
                    if (readState.IsCompleted)
                    {
                        var token = LexerToken.CreateSlashToken();
                        readState.EnqueueToken(token);
                        readState.MoveNext();

                        return;
                    }

                    var start = readState.CurrentIndex;
                    var end = readState.CurrentIndex.Next();

                    var range = new Range(start, end);

                    var identifierChars = readState.GetRange(range);

                    readState.SetStageScratchMemory(identifierChars);

                    readState.MoveNext();

                    return;
                }
            }
            else
            {
                readState.ClearStageScratchMemory();

                next = readState.CurrentChar;
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
                readState.MoveForCurrentAndNextChar();

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
            var options = new OneOrTwoCharsTokenizeOptions(CharConstants.Colon, LexerToken.CreateValueAssignmentToken)
            {
                { CharConstants.Colon, LexerToken.CreateNamespaceSeparatorToken }
            };

            HandleOneOrTwoCharsToken(ref readState, options);
        }

        private static void HandleAndToken(ref LexerSequenceReadState readState)
        {
            var options = new OneOrTwoCharsTokenizeOptions(CharConstants.And, LexerToken.CreateBinaryAndToken)
            {
                { CharConstants.And, LexerToken.CreateLogicalAndToken }
            };

            HandleOneOrTwoCharsToken(ref readState, options);
        }

        private static void HandleOrToken(ref LexerSequenceReadState readState)
        {
            var options = new OneOrTwoCharsTokenizeOptions(CharConstants.Or, LexerToken.CreateBinaryOrToken)
            {
                { CharConstants.Or, LexerToken.CreateLogicalOrToken }
            };

            HandleOneOrTwoCharsToken(ref readState, options);
        }

        private static void HandleNotToken(ref LexerSequenceReadState readState)
        {
            var options = new OneOrTwoCharsTokenizeOptions(CharConstants.Not, LexerToken.CreateLogicalNotToken)
            {
                { CharConstants.Equals, LexerToken.CreateInequalityToken }
            };

            HandleOneOrTwoCharsToken(ref readState, options);
        }

        private static void HandleEqualToken(ref LexerSequenceReadState readState)
        {
            var options = new OneOrTwoCharsTokenizeOptions(CharConstants.Equals, LexerToken.CreateFieldInitializationToken)
            {
                { CharConstants.Equals, LexerToken.CreateEqualityToken }
            };

            HandleOneOrTwoCharsToken(ref readState, options);
        }

        private static void HandleOneOrTwoCharsToken(ref LexerSequenceReadState readState, in OneOrTwoCharsTokenizeOptions options)
        {
            char nextChar;

            bool alreadyMovedFirstChar = false;

            // If there was a char in scratch memory
            if (readState.TryGetFirstCharScratchMemory(out char firstChar))
            {
                if (firstChar != options.FirstChar.Char)
                {
                    throw new NotImplementedException();
                }

                nextChar = readState.CurrentChar;
                alreadyMovedFirstChar = true;
            }
            // If there is no next char available
            // Save current char and return
            else if (readState.TryPeek(out nextChar) == false)
            {
                if (readState.IsCompleted)
                {
                    var token = options.FirstChar.CreateToken();
                    readState.EnqueueToken(token);
                    readState.MoveNext();

                    return;
                }

                // Save current colon for scratch memory and return
                readState.ClearAndSetCharOnStageScratchMemory(options.FirstChar.Char);

                readState.MoveNext();

                return;
            }

            if (options.TryGetTokenOptionsFor(nextChar, out var tokenOptions))
            {
                // then enqueue namespace separator token
                var token = tokenOptions.CreateToken();

                readState.EnqueueToken(token);
                readState.MoveNext();

                if (alreadyMovedFirstChar == false)
                {
                    // MoveNext for next char
                    readState.MoveNext();
                }
            }
            // If next char isn't on the list,
            else
            {
                // then enqueue single char token
                var token = options.FirstChar.CreateToken();

                readState.EnqueueToken(token);

                if (alreadyMovedFirstChar == false)
                {
                    readState.MoveNext();
                }
            }

            readState.MoveToState(LexerStatePhase.Searching);
        }

        private class OneOrTwoCharsTokenizeOptions : IEnumerable
        {
            private readonly Dictionary<char, CharTokenOptions> map;

            public OneOrTwoCharsTokenizeOptions(
                char firstChar,
                Func<LexerToken> createToken)
            {
                this.map = new Dictionary<char, CharTokenOptions>();
                this.FirstChar = new CharTokenOptions(firstChar, createToken);
            }

            public CharTokenOptions FirstChar { get; }

            public bool TryGetTokenOptionsFor(in char secondChar, out CharTokenOptions tokenOptions)
            {
                return this.map.TryGetValue(secondChar, out tokenOptions);
            }

            public void Add(in char secondChar, Func<LexerToken> createToken)
            {
                this.map.Add(secondChar, new CharTokenOptions(secondChar, createToken));
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        private class CharTokenOptions
        {
            public CharTokenOptions(char c, Func<LexerToken> createToken)
            {
                this.Char = c;
                this.CreateToken = createToken;
            }

            public char Char { get; }

            public Func<LexerToken> CreateToken { get; }
        }
    }
}
