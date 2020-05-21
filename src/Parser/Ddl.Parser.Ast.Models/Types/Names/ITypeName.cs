using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names
{
    public interface ITypeName
    {
        Identifier Name { get; }

        bool IsGeneric { get; }

        TypeNameKind Kind { get; }
    }
}
