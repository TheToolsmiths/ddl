using System.Buffers;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    internal class LexerState
    {
        public SourceReadingStats Stats { get; } = new SourceReadingStats();

        public LexerStatePhase StatePhase { get; private set; } = LexerStatePhase.Searching;

        public Queue<LexerToken> TokenQueue { get; } = new Queue<LexerToken>();

        public ArrayBufferWriter<char> StageScratchMemory { get; } = new ArrayBufferWriter<char>();

        public void MoveToState(LexerStatePhase phase)
        {
            this.StageScratchMemory.Clear();

            this.StatePhase = phase;
        }
    }
}
