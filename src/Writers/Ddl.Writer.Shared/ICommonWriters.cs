using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonWriters
    {
        Result WriteValueInitialization(CompiledValueInitialization initialization);

        Result WriteAttributes(AttributeUseCollection attributes);

        Result WriteTypeName(ItemTypeName typeName);

        Result WriteNamespace(NamespacePath namespacePath);

        Result WriteTypeReference(TypeUse typeUse);

        Result WriteStructInitialization(StructInitialization initialization);
    }
}
