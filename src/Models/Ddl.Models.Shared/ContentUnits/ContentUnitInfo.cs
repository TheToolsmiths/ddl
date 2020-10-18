using System.Diagnostics;
using System.IO;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
{
    [DebuggerDisplay("{" + nameof(RelativePath) + "}")]
    public class ContentUnitInfo
    {
        public ContentUnitInfo(string id, string name, string relativePath, FileInfo? file = null)
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

        public static ContentUnitInfo CreateFromFileInfo(FileInfo file, DirectoryInfo rootDirectory)
        {
            string relativePath = Path.GetRelativePath(rootDirectory.FullName, file.FullName);

            return CreateInfo(file.FullName, relativePath);
        }

        public static ContentUnitInfo CreateFromFileInfo(FileInfo file)
        {
            return CreateInfo(file.FullName, file.Name);
        }

        public static ContentUnitInfo CreateFromFilePath(string filePath)
        {
            return CreateInfo(filePath, Path.GetFileName(filePath));
        }

        private static ContentUnitInfo CreateInfo(string filePath, string relativePath)
        {
            string id = $"file///:{filePath}";
            string name = Path.GetFileNameWithoutExtension(filePath);

            return new ContentUnitInfo(id, name, relativePath, new FileInfo(filePath));
        }
    }
}
