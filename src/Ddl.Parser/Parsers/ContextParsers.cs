using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers.Implementations;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class ContextParsers
    {
        private readonly StructDefinitionContentParser structDefinitionContentParser;
        private readonly TypeIdentifierParser typeIdentifierParser;
        private readonly AttributeUsageParser attributeParser;
        private readonly StructValueInitializationParser structValueParser;
        private readonly LiteralValueInitializationParser literalValueParser;
        private readonly ConditionalExpressionParser conditionalExpressionsParser;
        private readonly FileRootContentParser fileRootContentParser;
        private readonly TypeNameParser typeNameParser;
        private readonly FieldInitializationParser fieldInitializationParser;

        public ContextParsers()
        {
            this.structDefinitionContentParser = new StructDefinitionContentParser();
            this.typeIdentifierParser = new TypeIdentifierParser();
            this.attributeParser = new AttributeUsageParser();
            this.structValueParser = new StructValueInitializationParser();
            this.literalValueParser = new LiteralValueInitializationParser();
            this.conditionalExpressionsParser = new ConditionalExpressionParser();
            this.fileRootContentParser = new FileRootContentParser();
            this.typeNameParser = new TypeNameParser();
            this.fieldInitializationParser = new FieldInitializationParser();
        }

        public Task<ParseResult<StructDefinitionContent>> ParseStructDefinitionContentParser(IParserContext context)
        {
            return this.structDefinitionContentParser.Parse(context);
        }

        public Task<ParseResult<ITypeIdentifier>> ParseTypeIdentifier(IParserContext context)
        {
            return this.typeIdentifierParser.Parse(context);
        }

        public Task<ParseResult<ITypeName>> ParseTypeName(IParserContext context)
        {
            return this.typeNameParser.ParseTypeName(context);
        }

        public Task<ParseResult<IReadOnlyList<IAttributeUse>>> ParseAttributeUseList(IParserContext context)
        {
            return this.attributeParser.ParseAttributeUseList(context);
        }

        public Task<ParseResult<StructValueInitialization>> ParseStructValueInitialization(IParserContext context)
        {
            return this.structValueParser.ParseStructuredInitialization(context);
        }

        public Task<ParseResult<LiteralValue>> ParseLiteralValue(IParserContext context)
        {
            return this.literalValueParser.ParseLiteralValue(context);
        }

        public Task<ParseResult<ConditionalExpression>> ParseConditionalExpressionRoot(IParserContext context)
        {
            return this.conditionalExpressionsParser.ParseConditionalExpressionRoot(context);
        }

        public Task<ParseResult<IReadOnlyList<IRootContentItem>>> ParseRootContentScope(IRootParserContext context)
        {
            return this.fileRootContentParser.ParseRootContentScope(context);
        }

        public Task<RootParseResult<IRootContentItem>> ParseRootContent(IRootParserContext context)
        {
            return this.fileRootContentParser.ParseRootContent(context);
        }

        public Task<ParseResult<ValueInitialization>> ParseFieldInitialization(IParserContext context)
        {
            return this.fieldInitializationParser.ParseFieldInitialization(context);
        }
    }
}
