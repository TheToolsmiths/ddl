using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public interface ITypeName
    {
        Identifier Name { get; }

        bool IsGeneric { get; }

        TypeNameType Type { get; }
    }
}