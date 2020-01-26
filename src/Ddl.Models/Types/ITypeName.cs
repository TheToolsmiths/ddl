using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public interface ITypeName
    {
        Identifier Name { get; }

        bool IsGeneric { get; }

        TypeNameType Type { get; }
    }
}