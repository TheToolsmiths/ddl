namespace TheToolsmiths.Ddl.Parser.Models.ImportPaths
{
    public class ResolvedImportIdentifierAlias : ResolvedImportItem
    {
        public ResolvedImportIdentifierAlias(string identifier, string aliasIdentifier)
        {
            this.Identifier = identifier;
            this.AliasIdentifier = aliasIdentifier;
        }

        public string Identifier { get; }

        public string AliasIdentifier { get; }

        public override ResolvedImportedItemKind ItemKind => ResolvedImportedItemKind.IdentifierAlias;

        public override string ToString()
        {
            return $"{this.Identifier} as {this.AliasIdentifier}";
        }
    }
}
