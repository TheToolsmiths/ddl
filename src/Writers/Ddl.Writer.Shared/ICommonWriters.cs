using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonWriters
    {
        Result WriteValueInitialization(ValueInitialization initialization);

        Result WriteAttributes(AttributeUseCollection attributes);

        Result WriteTypeName(TypedItemName typeNameItemName);

        Result WriteNamespace(NamespacePath namespacePath);
    }
}
