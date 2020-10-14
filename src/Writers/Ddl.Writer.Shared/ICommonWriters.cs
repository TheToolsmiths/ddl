using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonWriters
    {
        Result WriteValueInitialization(ValueInitialization initialization);

        Result WriteAttributes(AttributeUseCollection attributes);

        Result WriteTypeName(TypedItemName typeNameItemName);

        Result WriteNamespace(NamespacePath namespacePath);

        Result WriteTypeReference(TypeReference typeReference);

        Result WriteStructInitialization(StructInitialization initialization);
    }
}
