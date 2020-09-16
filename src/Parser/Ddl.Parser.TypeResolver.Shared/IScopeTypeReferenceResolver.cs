using TheToolsmiths.Ddl.Models.Types.References;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IScopeTypeReferenceResolver
    {
        TypeReference Resolve(TypeReference typeReference);
    }
}
