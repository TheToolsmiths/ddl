using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface ITypedAttributeUse : IAttributeUse
    {
        TypeIdentifier Type { get; }

        StructValueInitialization Initialization { get; }
    }
}