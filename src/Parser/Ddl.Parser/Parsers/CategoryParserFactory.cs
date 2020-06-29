using System;
using TheToolsmiths.Ddl.Parser.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class CategoryParserFactory : ICategoryParserFactory
    {
        private readonly IServiceProvider provider;

        public CategoryParserFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public IRootItemParser CreateCategoryParser(IParserMapRegistry registry)
        {
            var resolver = new RootParserResolver(this.provider, registry);

            return new CategoryRootParser(resolver);
        }
    }
}
