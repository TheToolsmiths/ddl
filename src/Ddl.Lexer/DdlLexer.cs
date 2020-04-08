using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer.Lexers;

namespace TheToolsmiths.Ddl.Lexer
{
    public class DdlLexer
    {
        private readonly ArrayBufferWriter<char> arrayBufferWriter;
        private readonly Decoder decoder;
        private readonly PipeReader streamReader;
        private readonly LexerState state;
        private bool isReadComplete;

        public DdlLexer(PipeReader streamReader, ArrayBufferWriter<char> arrayBufferWriter)
        {
            this.streamReader = streamReader;
            this.arrayBufferWriter = arrayBufferWriter;
            this.decoder = Encoding.UTF8.GetDecoder();

            this.state = new LexerState();
        }

        public bool HasNextToken
        {
            get
            {
                if (this.state.TokenQueue.Count > 0)
                {
                    return true;
                }

                return this.isReadComplete == false;
            }
        }

        public async Task<bool> TryParseTokens()
        {
            await this.ParseTokens();

            return this.HasNextToken;
        }

        public async ValueTask<TokenResult> TryGetNextToken()
        {
            {
                if (this.state.TokenQueue.TryDequeue(out var token))
                {
                    //Console.WriteLine($"Dequeued {token}");

                    return TokenResult.CreateResult(token);
                }
            }

            await this.ParseTokens();

            {
                if (this.state.TokenQueue.TryDequeue(out var token))
                {
                    //Console.WriteLine($"Dequeued {token}");

                    return TokenResult.CreateResult(token);
                }
            }

            return TokenResult.CreateNotFound();
        }

        public async ValueTask<TokenResult> TryPeekToken()
        {
            {
                if (this.state.TokenQueue.TryPeek(out var token))
                {
                    //Console.WriteLine($"Peeked {token}");

                    return TokenResult.CreateResult(token);
                }
            }

            await this.ParseTokens();

            {
                if (this.state.TokenQueue.TryPeek(out var token))
                {
                    //Console.WriteLine($"Peeked {token}");

                    return TokenResult.CreateResult(token);
                }
            }

            return TokenResult.CreateNotFound();
        }

        public async ValueTask<DoubleTokenResult> TryPeekNextTwoToken()
        {
            {
                if (this.state.TokenQueue.Count > 2)
                {
                    var first = this.state.TokenQueue.Peek();
                    var second = this.state.TokenQueue.ElementAt(1);

                    return DoubleTokenResult.CreateResult(first, second);
                }
            }

            await this.ParseTokens();

            {
                if (this.state.TokenQueue.Count > 2)
                {
                    var first = this.state.TokenQueue.Peek();
                    var second = this.state.TokenQueue.ElementAt(1);

                    return DoubleTokenResult.CreateResult(first, second);
                }
            }

            return DoubleTokenResult.CreateNotFound();
        }

        public void PopToken()
        {
            //Console.WriteLine($"Popped {this.state.TokenQueue.Peek()}");

            this.state.TokenQueue.Dequeue();
        }

        private async ValueTask ParseTokens()
        {
            while (true)
            {
                if (this.isReadComplete)
                {
                    return;
                }

                var readResult = await this.streamReader.ReadAsync();

                this.ReadBufferTokens(readResult);

                this.streamReader.AdvanceTo(readResult.Buffer.End);

                this.isReadComplete = readResult.IsCompleted;

                if (this.isReadComplete)
                {
                    await this.streamReader.CompleteAsync();
                }

                if (this.state.TokenQueue.Any())
                {
                    return;
                }

                if (this.isReadComplete)
                {
                    return;
                }
            }
        }

        private void ReadBufferTokens(ReadResult readResult)
        {
            var resultSequence = readResult.Buffer;

            foreach (var memory in resultSequence)
            {
                using var charsMemory = MemoryPool<char>.Shared.Rent(memory.Length * sizeof(char));

                var chars = charsMemory.Memory.Span;

                this.decoder.Convert(memory.Span, chars, false, out int bytesUsed, out int charsUsed, out bool completed);

                var lineBytes = memory.Span.Slice(0, bytesUsed);

                var foo = MemoryMarshal.Cast<char, byte>(chars);

                ReadOnlySpan<char> lineChars = chars.Slice(0, charsUsed);

                var readState = new LexerSequenceReadState(this.state, readResult.IsCompleted, lineChars, this.arrayBufferWriter);

                while (readState.HasCurrent)
                {
                    switch (this.state.StatePhase)
                    {
                        case LexerStatePhase.Searching:
                            SearchLexer.HandleSearchingPhase(ref readState);
                            break;
                        case LexerStatePhase.Identifier:
                            IdentifierLexer.HandleIdentifierPhase(ref readState);
                            break;
                        case LexerStatePhase.String:
                            StringLexer.HandleStringPhase(ref readState);
                            break;
                        case LexerStatePhase.NewLine:
                            NewLineLexer.HandleNewLinePhase(ref readState);
                            break;
                        case LexerStatePhase.Token:
                            TokenLexer.HandleTokenPhase(ref readState);
                            break;
                        case LexerStatePhase.Number:
                            NumberLexer.HandleNumberPhase(ref readState);
                            break;
                        case LexerStatePhase.LineComment:
                            CommentLexer.HandleLineComment(ref readState);
                            break;
                        case LexerStatePhase.BlockComment:
                            CommentLexer.HandleBlockComment(ref readState);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public async Task Initialize()
        {
            var readResult = await this.streamReader.ReadAsync();

            var buffer = readResult.Buffer;

            var position = SkipBom(buffer);

            this.streamReader.AdvanceTo(position);

            SequencePosition SkipBom(ReadOnlySequence<byte> sequence)
            {
                var span = sequence.FirstSpan;

                if (span.Length < 3)
                {
                    throw new Exception($"Initial file read is too short. {span.Length} byte(s).");
                }

                var start = sequence.Start;
                if (span[0] != 0xEF
                    || span[1] != 0xBB
                    || span[2] != 0xBF)
                {
                    return start;
                }

                return sequence.GetPosition(3);
            }

            this.isReadComplete = buffer.Length <= 3 && readResult.IsCompleted;
        }
    }
}
