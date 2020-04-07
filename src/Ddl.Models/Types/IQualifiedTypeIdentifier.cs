using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public interface IQualifiedTypeIdentifier : ITypeIdentifier
    {
        Identifier Name { get; }

        NamespacePath NamespacePath { get; }

        QualifiedTypeIdentifierKind QualifiedKind { get; }
        
        bool IsGeneric { get; }
    }
}
