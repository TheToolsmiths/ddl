using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    public class DdlLexer
    {
        private readonly ArrayBufferWriter<char> arrayBufferWriter;
        private readonly Decoder decoder;
        private readonly PipeReader streamReader;
        private readonly LexerState state;

        public DdlLexer(PipeReader streamReader, ArrayBufferWriter<char> arrayBufferWriter)
        {
            this.streamReader = streamReader;
            this.arrayBufferWriter = arrayBufferWriter;
            this.decoder = Encoding.UTF8.GetDecoder();

            this.state = new LexerState();
        }

        public async ValueTask<TokenResult> TryGetNextToken()
        {
            {
                if (this.state.TokenQueue.TryDequeue(out var token))
                {
                    return TokenResult.CreateResult(token);
                }
            }

            await this.ParseTokens();

            {
                if (this.state.TokenQueue.TryDequeue(out var token))
                {
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
                    return TokenResult.CreateResult(token);
                }
            }

            await this.ParseTokens();

            {
                if (this.state.TokenQueue.TryPeek(out var token))
                {
                    return TokenResult.CreateResult(token);
                }
            }

            return TokenResult.CreateNotFound();
        }

        public void PopToken()
        {
            this.state.TokenQueue.Dequeue();
        }

        private async ValueTask ParseTokens()
        {
            while (true)
            {
                var readResult = await this.streamReader.ReadAsync();

                this.ReadBufferTokens(readResult);

                this.streamReader.AdvanceTo(readResult.Buffer.End);

                if (this.state.TokenQueue.Any())
                {
                    return;
                }

                if (readResult.IsCompleted)
                {
                    await this.streamReader.CompleteAsync();
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
                        case LexerStatePhase.NewLine:
                            NewLineLexer.HandleNewLinePhase(ref readState);
                            break;
                        case LexerStatePhase.Token:
                            TokenLexer.HandleTokenPhase(ref readState);
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
        }
    }
}
