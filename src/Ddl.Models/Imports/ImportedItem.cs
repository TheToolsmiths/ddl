using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Imports
{
    public class ImportedItem
    {
        private ImportedItem(Identifier identifier, Identifier aliasIdentifier, bool isImportAll)
        {
            this.Identifier = identifier;
            this.AliasIdentifier = aliasIdentifier;
            this.IsImportAll = isImportAll;
        }

        public Identifier Identifier { get; }

        public Identifier AliasIdentifier { get; }

        public bool IsImportAll { get; }

        public static ImportedItem CreateAll(Identifier aliasIdentifier)
        {
            return new ImportedItem(Identifier.Empty, aliasIdentifier, true);
        }

        public static ImportedItem Create(Identifier identifier, Identifier aliasIdentifier)
        {
            return new ImportedItem(identifier, aliasIdentifier, false);
        }
    }
}
