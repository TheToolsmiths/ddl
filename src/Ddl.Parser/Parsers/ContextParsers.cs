using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Parser.Parsers.Implementations;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class ContextParsers
    {
        private readonly StructDefinitionContentParser structDefinitionContentParser;
        private readonly TypeIdentifierParser typeIdentifierParser;

        public ContextParsers()
        {
            this.structDefinitionContentParser = new StructDefinitionContentParser();
            this.typeIdentifierParser = new TypeIdentifierParser();
        }

        public Task<ParseResult<StructDefinitionContent>> ParseStructDefinitionContentParser(IParserContext context)
        {
            return this.structDefinitionContentParser.Parse(context);
        }

        public Task<ParseResult<ITypeIdentifier>> ParseTypeIdentifier(IParserContext context)
        {
            return this.typeIdentifierParser.Parse(context);
        }
    }
}
