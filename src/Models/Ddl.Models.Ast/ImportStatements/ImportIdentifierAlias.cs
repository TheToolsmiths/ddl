using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.ImportStatements
{
    public class ImportIdentifierAlias : ImportItem
    {
        private ImportIdentifierAlias(Identifier identifier, Identifier aliasIdentifier)
        {
            this.Identifier = identifier;
            this.AliasIdentifier = aliasIdentifier;
        }

        public Identifier Identifier { get; }

        public Identifier AliasIdentifier { get; }

        public override ImportedItemKind ItemKind => ImportedItemKind.IdentifierAlias;

        public static ImportItem Create(Identifier identifier, Identifier aliasIdentifier)
        {
            return new ImportIdentifierAlias(identifier, aliasIdentifier);
        }
    }
}
