using System;
using System.Buffers;

namespace TheToolsmiths.Ddl.Lexer
{
    internal ref struct LexerSequenceReadState
    {
        private readonly ArrayBufferWriter<char> arrayBufferWriter;
        private readonly LexerState state;
        private LexerCharEnumerator enumerator;

        public LexerSequenceReadState(LexerState state, bool isCompleted, in ReadOnlySpan<char> lineChars,
            ArrayBufferWriter<char> arrayBufferWriter)
        {
            this.IsCompleted = isCompleted;
            this.state = state;
            this.arrayBufferWriter = arrayBufferWriter;
            this.enumerator = new LexerCharEnumerator(lineChars);
        }

        public bool IsCompleted { get; }

        public char CurrentChar => this.enumerator.Current;

        public Index CurrentIndex => this.enumerator.CurrentIndex;

        public bool HasCurrent => this.enumerator.HasCurrent;

        public bool HasNext => this.enumerator.HasNext;

        public bool HasStageScratchMemory => this.state.HasStageScratchMemory;

        public bool MoveNext()
        {
            this.state.Stats.NextColumn();

            return this.enumerator.MoveNext();
        }

        public bool MoveForCurrentAndNextChar()
        {
            return this.MoveNext() && this.MoveNext();
        }

        public void NextLine()
        {
            this.state.Stats.NextLine();
        }

        public bool TryPeek(out char c)
        {
            return this.enumerator.TryPeek(out c);
        }

        public ReadOnlySpan<char> GetRange(in Range range)
        {
            return this.enumerator.GetRange(range);
        }

        public Memory<char> GetIdentifierMemory(int length)
        {
            var memory = this.arrayBufferWriter.GetMemory(length).Slice(0, length);

            this.arrayBufferWriter.Advance(memory.Length);

            return memory;
        }

        public void MoveToState(LexerStatePhase phase)
        {
            this.state.MoveToState(phase);
        }

        public void EnqueueToken(LexerToken lexerToken)
        {
            this.state.TokenQueue.Enqueue(lexerToken);
        }

        private Memory<char> GetStageScratchMemory(int length)
        {
            var memory = this.state.StageScratchMemory.GetMemory(length).Slice(0, length);

            this.state.StageScratchMemory.Advance(memory.Length);

            return memory;
        }

        public void SetStageScratchMemory(in ReadOnlySpan<char> chars)
        {
            var memory = this.GetStageScratchMemory(chars.Length);

            chars.CopyTo(memory.Span);

            this.state.HasStageScratchMemory = true;
        }

        public void ClearStageScratchMemory() => this.state.ClearStageScratchMemory();

        public void ClearAndSetCharOnStageScratchMemory(in char c)
        {
            var memory = this.ClearAndGetStageScratchMemory(1);

            memory.Span[0] = c;

            this.state.HasStageScratchMemory = true;
        }

        private Memory<char> ClearAndGetStageScratchMemory(int length)
        {
            this.state.StageScratchMemory.Clear();

            var memory = this.state.StageScratchMemory.GetMemory(length).Slice(0, length);

            this.state.StageScratchMemory.Advance(memory.Length);

            return memory;
        }

        public ReadOnlyMemory<char> GetWrittenStageScratchMemory()
        {
            return this.state.StageScratchMemory.WrittenMemory;
        }

        public bool TryGetFirstCharScratchMemory(out char firstScratchChar)
        {
            var writtenMemory = this.state.StageScratchMemory.WrittenMemory;

            if (writtenMemory.IsEmpty)
            {
                firstScratchChar = default;
                return false;
            }

            firstScratchChar = writtenMemory.Span[0];
            return true;
        }
    }
}
