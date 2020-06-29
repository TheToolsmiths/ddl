using TheToolsmiths.Ddl.Parser.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface ICategoryParserFactory
    {
        IRootItemParser CreateCategoryParser(IParserMapRegistry value);
    }
}
