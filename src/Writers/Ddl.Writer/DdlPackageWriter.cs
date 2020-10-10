using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Packager;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    internal class DdlPackageWriter : IDdlPackageWriter
    {
        public async Task<Result> WritePackage(IStructuredContentWriter writer, Package package)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("content");

            {
                writer.WriteStartObject();
                //ScopeContentWriter.WriteScopeContent(writer, contentUnit.RootScope.Content);
                writer.WriteEndObject();
            }

            writer.WriteEndObject();

            return Result.Success;
        }
    }
}
