using System;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class IndexHelpers
    {
        public static Index Next(this Index index)
        {
            return index.IsFromEnd ? new Index(index.Value - 1, true) : new Index(index.Value + 1);
        }
    }
}
