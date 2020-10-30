using System;
using TheToolsmiths.Ddl.Writer.Common;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Contexts
{
    internal class CompiledItemWriterContext : ICompiledItemWriterContext
    {
        public CompiledItemWriterContext(
            IServiceProvider provider,
            IStructuredContentWriter writer)
        {
            this.Writer = writer;
            this.CommonWriters = new CommonItemWriters(provider, this);
        }

        public ICommonItemWriters CommonWriters { get; }

        public IStructuredContentWriter Writer { get; }

        ICommonWriters ICompiledEntryWriterContext.CommonWriters => this.CommonWriters;
    }
}
