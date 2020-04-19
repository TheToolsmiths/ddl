using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Shared
{
    public interface ICommonParsers
    {
        Task<ParseResult<StructDefinitionContent>> ParseStructDefinitionContentParser();

        Task<ParseResult<ITypeIdentifier>> ParseTypeIdentifier();

        Task<ParseResult<ITypeName>> ParseTypeName();

        Task<ParseResult<IReadOnlyList<IAttributeUse>>> ParseAttributeUseList();

        Task<ParseResult<StructValueInitialization>> ParseStructValueInitialization();

        Task<ParseResult<LiteralValue>> ParseLiteralValue();

        Task<ParseResult<ConditionalExpression>> ParseConditionalExpressionRoot();

        Task<ParseResult<ValueInitialization>> ParseFieldInitialization();
    }
}
