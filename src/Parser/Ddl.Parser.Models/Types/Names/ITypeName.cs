using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public interface ITypeName
    {
        Identifier Name { get; }

        bool IsGeneric { get; }

        TypeNameKind Kind { get; }
    }
}
