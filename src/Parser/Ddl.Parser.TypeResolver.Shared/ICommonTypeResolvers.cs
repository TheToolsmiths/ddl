using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface ICommonTypeResolvers
    {
        Result<ScopeContent> ResolveScopeContent(ScopeContent scopeContent);

        Result<IReadOnlyList<IAttributeUse>> ResolveAttributes(IReadOnlyList<IAttributeUse> attributes);

        Result<StructDefinitionContent> ResolveStructDefinitionContent(StructDefinitionContent content);

        Result<ValueInitialization> ResolveValueInitialization(ValueInitialization initialization);
    }
}
