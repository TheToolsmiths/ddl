using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class CategoryRootParser : IEnumerable<KeyValuePair<string, IRootParser>>, IRootParser
    {
        private readonly CharSpanKeyedMap<IRootParser> categoryParsersMap;

        public CategoryRootParser()
        {
            this.categoryParsersMap = new CharSpanKeyedMap<IRootParser>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, IRootParser>> GetEnumerator()
        {
            return this.categoryParsersMap.GetEnumerator();
        }

        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (this.categoryParsersMap.TryGetValue(token.Memory, out var parser) == false)
            {
                string[] identifiers = { token.Memory.Span.ToString() };
                return RootParseResult<IRootContentItem>.CreateParserHandlerNotFound(identifiers);
            }

            return await parser.ParseRootContent(context);
        }

        public void Add(string key, IRootParser rootParser)
        {
            this.categoryParsersMap.Add(key, rootParser);
        }
    }
}
