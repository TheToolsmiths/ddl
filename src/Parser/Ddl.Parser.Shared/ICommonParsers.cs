using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.Literals;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;

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
