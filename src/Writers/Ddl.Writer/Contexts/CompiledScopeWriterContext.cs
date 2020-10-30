using System;

using TheToolsmiths.Ddl.Writer.Common;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public class CompiledScopeWriterContext : ICompiledScopeWriterContext
    {
        public CompiledScopeWriterContext(
            IServiceProvider provider,
            IStructuredContentWriter writer)
        {
            this.Writer = writer;
            this.CommonWriters = new CommonScopeWriters(provider, this);
        }

        public ICommonScopeWriters CommonWriters { get; }

        public IStructuredContentWriter Writer { get; }

        ICommonWriters ICompiledEntryWriterContext.CommonWriters => this.CommonWriters;
    }
}
