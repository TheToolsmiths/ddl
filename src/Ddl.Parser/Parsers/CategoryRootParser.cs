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
    internal class CategoryRootParser<TContext> : IEnumerable<KeyValuePair<string, IRootParser<TContext>>>,
        IRootParser<TContext> where TContext : RootParserContext
    {
        private readonly CharSpanKeyedMap<IRootParser<TContext>> categoryParsersMap;

        protected CategoryRootParser()
        {
            this.categoryParsersMap = new CharSpanKeyedMap<IRootParser<TContext>>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, IRootParser<TContext>>> GetEnumerator()
        {
            return this.categoryParsersMap.GetEnumerator();
        }

        public async ValueTask<ParseResult<IRootContentItem>> ParseRootContent(TContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (this.categoryParsersMap.TryGetValue(token.Memory, out var parser) == false)
            {
                throw new NotImplementedException();
            }

            return await parser.ParseRootContent(context);
        }

        public void Add(string key, IRootParser<TContext> rootParser)
        {
            this.categoryParsersMap.Add(key, rootParser);
        }
    }
}
