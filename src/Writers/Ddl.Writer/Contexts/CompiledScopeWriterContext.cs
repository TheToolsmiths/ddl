using System;

using TheToolsmiths.Ddl.Writer.Common;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Contexts
{
    public class CompiledScopeWriterContext : ICompiledScopeWriterContext
    {
        public CompiledScopeWriterContext(
            IServiceProvider provider,
            IStructuredContentWriter writer,
            IEntityKeyMap entityKeyMap)
        {
            this.Writer = writer;
            this.EntityKeyMap = entityKeyMap;
            this.CommonWriters = new CommonScopeWriters(provider, this);
        }

        public ICommonScopeWriters CommonWriters { get; }

        public IEntityKeyMap EntityKeyMap { get; }

        public IStructuredContentWriter Writer { get; }

        ICommonWriters ICompiledEntryWriterContext.CommonWriters => this.CommonWriters;
    }
}
