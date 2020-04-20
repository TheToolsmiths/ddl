namespace TheToolsmiths.Ddl.Lexer
{
    internal enum LexerStatePhase
    {
        Searching,
        Identifier,
        NewLine,
        Token,
        LineComment,
        BlockComment,
        String,
        Number
    }
}
