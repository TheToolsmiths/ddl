using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface ICommonTypeResolvers
    {
        Result<ScopeContent> ResolveScopeContent(ScopeContent scopeContent);

        Result<AttributeUseCollection> ResolveAttributes(AttributeUseCollection attributes);

        Result<StructDefinitionContent> ResolveStructDefinitionContent(StructDefinitionContent content);

        Result<ValueInitialization> ResolveValueInitialization(ValueInitialization initialization);
    }
}
