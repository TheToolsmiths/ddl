﻿namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface ICategoryParserFactory
    {
        IRootItemParser CreateCategoryParser(IParserMapRegistry value);
    }
}
