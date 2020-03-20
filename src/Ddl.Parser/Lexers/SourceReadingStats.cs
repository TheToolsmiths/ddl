namespace TheToolsmiths.Ddl.Parser.Lexers
{
    public class SourceReadingStats
    {
        private const int InitialColumn = 1;

        public int CurrentLine { get; private set; } = 1;

        public int CurrentColumn { get; private set; } = InitialColumn;

        public void NextLine()
        {
            this.CurrentLine++;
            this.CurrentColumn = InitialColumn;
        }

        public void NextColumn()
        {
            this.CurrentColumn++;
        }
    }
}
