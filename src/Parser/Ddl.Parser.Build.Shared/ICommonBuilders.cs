using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Ast.Values;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Build.Literals;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Results;

using ValueInitialization = TheToolsmiths.Ddl.Models.Build.Values.ValueInitialization;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface ICommonBuilders
    {
        Result<AttributeUseCollection> BuildAttributes(AstAttributeUseCollection attributes);

        Result<ScopeContent> BuildScopeContent(AstScopeContent astScopeContent);

        Result<StructDefinitionContent> BuildStructContent(Models.Ast.Structs.StructDefinitionContent content);

        Result<ConditionalExpression> BuildConditionalExpression(AstConditionalExpression conditionalExpression);

        Result<StructInitialization> BuildStructInitialization(StructValueInitialization astInitialization);

        Result<ValueInitialization> BuildValueInitialization(Models.Ast.Values.ValueInitialization astInitialization);

        Result<LiteralValue> BuildLiteral(Models.Ast.Literals.LiteralValue astLiteral);
    }
}
