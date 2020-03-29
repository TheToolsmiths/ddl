using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.AttributeUsage;
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

        public ContextParsers()
        {
            this.structDefinitionContentParser = new StructDefinitionContentParser();
            this.typeIdentifierParser = new TypeIdentifierParser();
            this.attributeParser = new AttributeUsageParser();
            this.structValueParser = new StructValueInitializationParser();
            this.literalValueParser = new LiteralValueInitializationParser();
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
            return this.typeIdentifierParser.ParseTypeName(context);
        }

        public Task<ParseResult<IReadOnlyList<IAttributeUse>>> ParseAttributeUseList(IParserContext context)
        {
            return this.attributeParser.ParseAttributeUseList(context);
        }

        public Task<ParseResult<TypedStructValueInitialization>> ParseTypedStructValueInitialization(IParserContext context)
        {
            return this.structValueParser.ParseTypedStructuredInitialization(context);
        }

        public Task<ParseResult<StructValueInitialization>> ParseStructValueInitialization(IParserContext context)
        {
            return this.structValueParser.ParseStructuredInitialization(context);
        }

        public Task<ParseResult<LiteralValueInitialization>> ParseLiteralValueInitialization(IParserContext context)
        {
            return this.literalValueParser.ParseLiteralValueInitialization(context);
        }

        public Task<ParseResult<LiteralValue>> ParseLiteralValue(IParserContext context)
        {
            return this.literalValueParser.ParseLiteralValue(context);
        }
    }
}
