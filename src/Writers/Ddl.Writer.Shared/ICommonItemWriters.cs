using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonItemWriters : ICommonWriters
    {
        Result WriteStructDefinitionContent(StructDefinitionContent content);

        Result WriteTypeNameResolution(QualifiedItemTypeNameResolution typeNameResolution);
    }
}
