using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Ast.Models.Imports;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins
{
    public class ImplementationsBuilderRegister : IRootBuilderRegister
    {
        public void RegisterBuilders(IBuilderMapRegistryBuilder builder)
        {
            builder.RegisterItemBuilder<EnumDefinitionBuilder, EnumAstDefinition>();
            builder.RegisterItemBuilder<EnumStructDefinitionBuilder, EnumStructAstDefinition>();
            builder.RegisterItemBuilder<StructDefinitionBuilder, StructAstDefinition>();
            builder.RegisterItemBuilder<ImportStatementBuilder, ImportAstStatement>();

            builder.RegisterScopeBuilder<ConditionalRootScopeBuilder, ConditionalAstRootScope>();
        }
    }
}
