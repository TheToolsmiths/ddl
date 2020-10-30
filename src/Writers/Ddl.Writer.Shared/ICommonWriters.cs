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

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonWriters
    {
        Result WriteValueInitialization(CompiledValueInitialization initialization);

        Result WriteCompiledAttributes(CompiledAttributeUseCollection attributes);

        Result WriteQualifiedTypeName(QualifiedItemTypeName typeName);

        Result WriteQualifiedNamespace(QualifiedNamespacePath namespacePath);

        Result WriteTypeUse(ResolvedTypeUse typeUse);

        Result WriteStructInitialization(CompiledStructInitialization initialization);

        Result WriteTypeNameIdentifier(TypeNameIdentifier typeName);

        Result WriteLiteralValue(LiteralValue literalValue);

        Result WriteTypeUse(TypeUse typeUse);

        Result WriteTypeUseLocality(TypeUseLocality locality);

        Result WriteTypeUseModifiers(TypeUseModifiers modifiers);

        Result WriteTypeUseStorage(TypeUseStorage storage);

        Result WriteConditionalExpression(ConditionalExpression conditionalExpression);
    }
}
