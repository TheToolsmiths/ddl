using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Common
{
    public class CommonTypeResolvers : ICommonTypeResolvers
    {
        private readonly IServiceProvider provider;
        private readonly IRootScopeTypeResolveContext context;

        public CommonTypeResolvers(IServiceProvider serviceProvider, IRootScopeTypeResolveContext context)
        {
            this.provider = serviceProvider;
            this.context = context;
        }

        public CommonTypeResolvers CreateForScope(IRootScopeTypeResolveContext scopeContext)
        {
            return new CommonTypeResolvers(this.provider, scopeContext);
        }

        public Result<ScopeContent> ResolveScopeContent(ScopeContent scopeContent)
        {
            return this.provider.GetRequiredService<ScopeContentTypeResolver>().ResolveScopeContent(this.context, scopeContent);
        }

        public Result<AttributeUseCollection> ResolveAttributes(AttributeUseCollection attributes)
        {
            return this.provider.GetRequiredService<AttributesTypeResolver>().ResolveAttributes(this.context, attributes);
        }

        public Result<StructDefinitionContent> ResolveStructDefinitionContent(StructDefinitionContent content)
        {
            return this.provider.GetRequiredService<StructDefinitionContentTypeResolver>().Resolve(this.context, content);
        }

        public Result<ValueInitialization> ResolveValueInitialization(ValueInitialization initialization)
        {
            return this.provider.GetRequiredService<ValueInitializationTypeResolver>().Resolve(this.context, initialization);
        }
    }
}
