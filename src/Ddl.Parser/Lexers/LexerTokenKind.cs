namespace TheToolsmiths.Ddl.Parser.Lexers
{
    public enum LexerTokenKind
    {
        Identifier,
        OpenScope,
        CloseScope,
        ValueAssignment,
        NamespaceSeparator,
        Slash,
        ListSeparator,
        FieldInitialization
    }
}
