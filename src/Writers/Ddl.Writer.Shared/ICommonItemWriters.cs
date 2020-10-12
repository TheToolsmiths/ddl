using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonItemWriters : ICommonWriters
    {
        Result WriteStructDefinitionContent(StructDefinitionContent content);

        Result WriteTypeNameResolution(QualifiedItemTypeNameResolution typeNameResolution);
    }
}
