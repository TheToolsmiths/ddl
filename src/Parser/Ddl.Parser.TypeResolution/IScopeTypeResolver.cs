using TheToolsmiths.Ddl.Models.Types.References;

namespace TheToolsmiths.Ddl.TypeResolution
{
    public interface IScopeTypeResolver
    {
        Result<TypeReference> ResolveTypeReference(TypeReference typeReference);
    }
}
