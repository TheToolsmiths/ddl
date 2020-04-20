using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Parser.Shared;

namespace TheToolsmiths.Ddl.Parser.Parsers.ParserMaps
{
    internal class ParserMapRegistry : IParserMapRegistry
    {
        private readonly ParserCategoryRegistry rootRegistry;

        public ParserMapRegistry(ParserCategoryRegistry rootRegistry)
        {
            this.rootRegistry = rootRegistry;
        }

        public bool TryGetParser(in ReadOnlySpan<char> key, [MaybeNullWhen(false)]  out IRootItemParser itemParser)
        {
            return this.rootRegistry.TryGetParser(key, out itemParser);
        }
    }
}
