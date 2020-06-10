using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser
{
    public interface ICommonParsers
    {
        Task<Result<StructDefinitionContent>> ParseStructDefinitionContentParser();

        Task<Result<ITypeIdentifier>> ParseTypeIdentifier();

        Task<Result<IGenericParameterTypeIdentifier>> ParseGenericParameterTypeIdentifier();

        Task<Result<TypeName>> ParseTypeName();

        Task<Result<IReadOnlyList<IAstAttributeUse>>> ParseAttributeUseList();

        Task<Result<StructValueInitialization>> ParseStructValueInitialization();

        Task<Result<LiteralValue>> ParseLiteralValue();

        Task<Result<ConditionalExpression>> ParseConditionalExpressionRoot();

        Task<Result<ValueInitialization>> ParseFieldInitialization();
    }
}
