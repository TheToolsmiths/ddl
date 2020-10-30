using System;

using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Usage;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Common.Attributes;
using TheToolsmiths.Ddl.Writer.Common.ConditionalExpressions;
using TheToolsmiths.Ddl.Writer.Common.Types;
using TheToolsmiths.Ddl.Writer.Common.Values;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common
{
    public abstract class CommonWriters : ICommonWriters
    {
        private readonly ICompiledEntryWriterContext context;

        protected CommonWriters(IServiceProvider provider, ICompiledEntryWriterContext context)
        {
            this.context = context;
            this.Provider = provider;
        }

        protected IServiceProvider Provider { get; }

        public Result WriteValueInitialization(CompiledValueInitialization initialization)
        {
            return this.Provider.GetRequiredService<CompiledValueInitializationWriter>().Write(this.context, initialization);
        }

        public Result WriteCompiledAttributes(CompiledAttributeUseCollection attributes)
        {
            return this.Provider.GetRequiredService<CompiledAttributesWriter>().Write(this.context, attributes);
        }

        public Result WriteQualifiedTypeName(QualifiedItemTypeName typeName)
        {
            return this.Provider.GetRequiredService<QualifiedTypeNameWriter>().Write(this.context, typeName);
        }

        public Result WriteQualifiedNamespace(QualifiedNamespacePath namespacePath)
        {
            return this.Provider.GetRequiredService<QualifiedNamespaceWriter>().Write(this.context, namespacePath);
        }

        public Result WriteTypeUse(ResolvedTypeUse typeUse)
        {
            return this.Provider.GetRequiredService<ResolvedTypeUseWriter>().Write(this.context, typeUse);
        }

        public Result WriteTypeUse(TypeUse typeUse)
        {
            return this.Provider.GetRequiredService<TypeUseWriter>().Write(this.context, typeUse);
        }

        public Result WriteTypeUseLocality(TypeUseLocality locality)
        {
            return this.Provider.GetRequiredService<TypeUseWriter>().WriteTypeUseLocality(this.context, locality);
        }

        public Result WriteTypeUseModifiers(TypeUseModifiers modifiers)
        {
            return this.Provider.GetRequiredService<TypeUseWriter>().WriteTypeUseModifiers(this.context, modifiers);
        }

        public Result WriteTypeUseStorage(TypeUseStorage storage)
        {
            return this.Provider.GetRequiredService<TypeUseWriter>().WriteTypeUseStorage(this.context, storage);
        }

        public Result WriteConditionalExpression(ConditionalExpression conditionalExpression)
        {
            return this.Provider.GetRequiredService<ConditionalExpressionsWriter>().Write(this.context, conditionalExpression);
        }

        public Result WriteStructInitialization(CompiledStructInitialization initialization)
        {
            return this.Provider.GetRequiredService<CompiledValueInitializationWriter>().WriteStructInitialization(this.context, initialization);
        }

        public Result WriteTypeNameIdentifier(TypeNameIdentifier typeName)
        {
            return this.Provider.GetRequiredService<TypeNameIdentifierWriter>().Write(this.context, typeName);
        }

        public Result WriteLiteralValue(LiteralValue literalValue)
        {
            return this.Provider.GetRequiredService<LiteralValueWriter>().Write(this.context, literalValue);
        }
    }
}
