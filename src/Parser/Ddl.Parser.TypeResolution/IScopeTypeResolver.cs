using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.TypeResolution
{
    public interface IScopeTypeResolver
    {
        Result<TypeReference> ResolveTypeReference(TypeReference typeReference);
    }
}
