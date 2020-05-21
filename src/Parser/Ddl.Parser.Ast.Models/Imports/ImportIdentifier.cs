using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Imports
{
    public class ImportIdentifier : ImportItem
    {
        public ImportIdentifier(Identifier identifier)
        {
            this.Identifier = identifier;
        }

        public Identifier Identifier { get; }

        public override ImportedItemKind ItemKind => ImportedItemKind.Identifier;

        public static ImportIdentifier Create(Identifier identifier)
        {
            return new ImportIdentifier(identifier);
        }
    }
}
