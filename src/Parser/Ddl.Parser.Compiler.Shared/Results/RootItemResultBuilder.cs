using System;
using TheToolsmiths.Ddl.Models.Compiled.Items;

namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootItemResultBuilder
    {
        public ICompiledItem? Item { get; set; }

        public RootItemCompileSuccess CreateSuccessResult()
        {
            if (this.Item == null)
            {
                throw new NotImplementedException();
            }

            return new RootItemCompileSuccess(this.Item);
        }
    }
}
