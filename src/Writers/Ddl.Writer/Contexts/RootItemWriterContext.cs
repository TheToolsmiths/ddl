using System;
using TheToolsmiths.Ddl.Writer.Common;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Contexts
{
    internal class RootItemWriterContext : IRootItemWriterContext
    {
        public RootItemWriterContext(
            IServiceProvider provider,
            IStructuredContentWriter writer)
        {
            this.Writer = writer;
            this.CommonWriters = new CommonItemWriters(provider, this);
        }

        public ICommonItemWriters CommonWriters { get; }

        public IStructuredContentWriter Writer { get; }

        ICommonWriters IRootEntryWriterContext.CommonWriters => this.CommonWriters;
    }
}
