using System.Diagnostics;
using System.IO;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits
{
    [DebuggerDisplay("{" + nameof(RelativePath) + "}")]
    public class AstContentUnitInfo
    {
        public AstContentUnitInfo(string id, string name, string relativePath, FileInfo? file = null)
        {
            this.Name = name;
            this.RelativePath = relativePath;
            this.File = file;
            this.Id = id;
        }

        public string Id { get; }

        public string Name { get; }

        public string RelativePath { get; }

        public FileInfo? File { get; }

        public override string ToString()
        {
            return this.Name;
        }

        public static AstContentUnitInfo CreateFromFileInfo(FileInfo file, DirectoryInfo rootDirectory)
        {
            string relativePath = Path.GetRelativePath(rootDirectory.FullName, file.FullName);

            return CreateInfo(file, relativePath);
        }

        private static AstContentUnitInfo CreateInfo(FileInfo file, string relativePath)
        {
            string id = $"file///:{file.FullName}";
            string name = Path.GetFileNameWithoutExtension(file.Name);

            return new AstContentUnitInfo(id, name, relativePath, file);
        }

        public static AstContentUnitInfo CreateFromFileInfo(FileInfo file)
        {
            return CreateInfo(file, file.Name);
        }
    }
}
