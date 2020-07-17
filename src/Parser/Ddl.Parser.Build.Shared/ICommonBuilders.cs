using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Results;

using ValueInitialization = TheToolsmiths.Ddl.Models.Values.ValueInitialization;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface ICommonBuilders
    {
        Result<IReadOnlyList<IAttributeUse>> BuildAttributes(IReadOnlyList<IAstAttributeUse> attributes);

        Result<ScopeContent> BuildScopeContent(AstScopeContent astScopeContent);

        Result<StructDefinitionContent> BuildStructContent(Ast.Models.Structs.StructDefinitionContent content);

        Result<ConditionalExpression> BuildConditionalExpression(AstConditionalExpression conditionalExpression);

        Result<StructInitialization> BuildStructInitialization(StructValueInitialization astInitialization);

        Result<ValueInitialization> BuildValueInitialization(Ast.Models.Values.ValueInitialization astInitialization);

        Result<Models.Literals.LiteralValue> BuildLiteral(LiteralValue astLiteral);
    }
}
