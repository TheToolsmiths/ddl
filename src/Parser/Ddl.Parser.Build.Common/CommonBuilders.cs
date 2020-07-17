using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;

using ValueInitialization = TheToolsmiths.Ddl.Models.Values.ValueInitialization;

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

        public Result<IReadOnlyList<IAttributeUse>> BuildAttributes(
            IReadOnlyList<Ast.Models.AttributeUsage.IAstAttributeUse> attributes)
        {
            return this.provider.GetRequiredService<AttributeUseBuilder>().BuildList(this.context, attributes);
        }

        public Result<ScopeContent> BuildScopeContent(AstScopeContent astScopeContent)
        {
            return this.provider.GetRequiredService<ScopeContentBuilder>().BuildScopeContent(this.context, astScopeContent);
        }

        public Result<StructDefinitionContent> BuildStructContent(Ast.Models.Structs.StructDefinitionContent content)
        {
            return this.provider.GetRequiredService<StructDefinitionContentBuilder>().BuildContent(this.context, content);
        }

        public Result<ConditionalExpression> BuildConditionalExpression(Ast.Models.ConditionalExpressions.AstConditionalExpression conditionalExpression)
        {
            return this.provider.GetRequiredService<ConditionalExpressionBuilder>().BuildExpression(this.context, conditionalExpression);
        }

        public Result<ValueInitialization> BuildValueInitialization(
            Ast.Models.Values.ValueInitialization astInitialization)
        {
            return this.provider.GetRequiredService<ValueInitializationBuilder>().BuildValueInitialization(this.context, astInitialization);
        }

        public Result<StructInitialization> BuildStructInitialization(StructValueInitialization astInitialization)
        {
            return this.provider.GetRequiredService<ValueInitializationBuilder>().BuildStructInitialization(this.context, astInitialization);
        }

        public Result<Models.Literals.LiteralValue> BuildLiteral(LiteralValue astLiteral)
        {
            return this.provider.GetRequiredService<LiteralValueBuilder>().BuildLiteral(this.context, astLiteral);
        }
    }
}
