namespace TheToolsmiths.Ddl.Parser.Lexers
{
    internal enum LexerStatePhase
    {
        Searching,
        Identifier,
        NewLine,
        Token,
        LineComment,
        BlockComment
    }
}
