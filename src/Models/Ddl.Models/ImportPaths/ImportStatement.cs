using System.Linq;

namespace TheToolsmiths.Ddl.Models.ImportPaths
{
    public class ImportStatement
    {
        public ImportStatement(ImportPath importPath, string aliasIdentifier)
        {
            this.ImportPath = importPath;
            this.Alias = aliasIdentifier;
        }

        public ImportPath ImportPath { get; }

        public string Alias { get; }

        public override string ToString()
        {
            return $"{this.ImportPath} as {this.Alias}";
        }

        public static ImportStatement Create(ImportPath importPath)
        {
            string alias = importPath.PathIdentifiers.Last();

            return new ImportStatement(importPath, alias);
        }

        public static ImportStatement CreateWithAlias(ImportPath importPath, string alias)
        {
            return new ImportStatement(importPath, alias);
        }
    }
}
