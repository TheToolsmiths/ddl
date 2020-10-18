using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Ast.Values;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;

using ValueInitialization = TheToolsmiths.Ddl.Models.Build.Values.ValueInitialization;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class CommonBuilders : ICommonBuilders
    {
        private readonly IServiceProvider provider;
        private readonly IRootScopeBuildContext context;

        public CommonBuilders(IServiceProvider serviceProvider, IRootScopeBuildContext context)
        {
            this.provider = serviceProvider;
            this.context = context;
        }

        public CommonBuilders CreateForScope(IRootScopeBuildContext scopeContext)
        {
            return new CommonBuilders(this.provider, scopeContext);
        }

        public Result<AttributeUseCollection> BuildAttributes(AstAttributeUseCollection attributes)
        {
            return this.provider.GetRequiredService<AttributeUseBuilder>().BuildList(this.context, attributes);
        }

        public Result<ScopeContent> BuildScopeContent(AstScopeContent astScopeContent)
        {
            return this.provider.GetRequiredService<ScopeContentBuilder>().BuildScopeContent(this.context, astScopeContent);
        }

        public Result<StructContent> BuildStructContent(Models.Ast.Structs.StructDefinitionContent content)
        {
            return this.provider.GetRequiredService<StructDefinitionContentBuilder>().BuildContent(this.context, content);
        }

        public Result<ConditionalExpression> BuildConditionalExpression(AstConditionalExpression conditionalExpression)
        {
            return this.provider.GetRequiredService<ConditionalExpressionBuilder>().BuildExpression(this.context, conditionalExpression);
        }

        public Result<ValueInitialization> BuildValueInitialization(
            Models.Ast.Values.ValueInitialization astInitialization)
        {
            return this.provider.GetRequiredService<ValueInitializationBuilder>().BuildValueInitialization(this.context, astInitialization);
        }

        public Result<StructInitialization> BuildStructInitialization(StructValueInitialization astInitialization)
        {
            return this.provider.GetRequiredService<ValueInitializationBuilder>().BuildStructInitialization(this.context, astInitialization);
        }

        public Result<LiteralValue> BuildLiteral(Models.Ast.Literals.LiteralValue astLiteral)
        {
            return this.provider.GetRequiredService<LiteralValueBuilder>().BuildLiteral(this.context, astLiteral);
        }
    }
}
