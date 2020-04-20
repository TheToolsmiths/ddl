using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public interface IQualifiedTypeIdentifier : ITypeIdentifier
    {
        Identifier Name { get; }

        NamespacePath NamespacePath { get; }

        QualifiedTypeIdentifierKind QualifiedKind { get; }
        
        bool IsGeneric { get; }
    }
}
