using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.Literals;
using TheToolsmiths.Ddl.Models.Ast.Structs;
using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;
using TheToolsmiths.Ddl.Models.Ast.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser
{
    public interface ICommonParsers
    {
        Task<Result<StructDefinitionContent>> ParseStructDefinitionContentParser();

        Task<Result<ITypeIdentifier>> ParseTypeIdentifier();

        Task<Result<IGenericParameterTypeIdentifier>> ParseGenericParameterTypeIdentifier();

        Task<Result<TypeName>> ParseTypeName();

        Task<Result<AstAttributeUseCollection>> ParseAttributeUseList();

        Task<Result<StructValueInitialization>> ParseStructValueInitialization();

        Task<Result<LiteralValue>> ParseLiteralValue();

        Task<Result<AstConditionalExpression>> ParseConditionalExpressionRoot();

        Task<Result<ValueInitialization>> ParseFieldInitialization();
    }
}
