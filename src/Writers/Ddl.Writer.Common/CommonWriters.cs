﻿using System;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Common.Attributes;
using TheToolsmiths.Ddl.Writer.Common.TypeNames;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common
{
    public abstract class CommonWriters : ICommonWriters
    {
        private readonly IRootEntryWriterContext context;

        protected CommonWriters(IServiceProvider provider, IRootEntryWriterContext context)
        {
            this.context = context;
            this.Provider = provider;
        }

        protected IServiceProvider Provider { get; }

        public Result WriteValueInitialization(ValueInitialization initialization)
        {
            throw new NotImplementedException();
        }

        public Result WriteAttributes(AttributeUseCollection attributes)
        {
            return this.Provider.GetRequiredService<AttributesWriter>().Write(this.context, attributes);
        }

        public Result WriteTypeName(TypedItemName typeName)
        {
            return this.Provider.GetRequiredService<TypeNameWriter>().Write(this.context, typeName);
        }

        public Result WriteNamespace(NamespacePath namespacePath)
        {
            return this.Provider.GetRequiredService<NamespaceWriter>().Write(this.context, namespacePath);
        }
    }
}
