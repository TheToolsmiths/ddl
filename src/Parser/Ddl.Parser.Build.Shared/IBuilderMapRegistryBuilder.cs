using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IBuilderMapRegistryBuilder
    {
        void RegisterItemBuilder<TBuilder, TAstItem>()
            where TBuilder : IRootItemBuilder<TAstItem>
            where TAstItem : class, IAstRootItem;

        void RegisterScopeBuilder<TBuilder, TAstScope>()
            where TBuilder : IRootScopeBuilder<TAstScope>
            where TAstScope : class, IAstRootScope;
    }
}
