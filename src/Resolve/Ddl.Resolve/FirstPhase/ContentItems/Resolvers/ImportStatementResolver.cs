using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using TheToolsmiths.Ddl.Parser.Models.Imports;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class ImportStatementResolver : IRootContentItemResolver<ImportStatement>
    {
        public Result CatalogItem(
            ContentUnitScopeResolveContext unitContext,
            ImportStatement importStatement)
        {
            var content = new ImportResolvedContent();

            var item = new FirstPhaseResolvedItem(content, null);

            unitContext.ResolvedItems.Add(item);

            // TODO: Add imported types and type alias to unit context

            return Result.Success;
        }
    }
}
