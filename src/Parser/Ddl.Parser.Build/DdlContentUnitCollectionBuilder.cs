using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    internal class DdlContentUnitCollectionBuilder : IDdlContentUnitCollectionBuilder
    {
        private readonly DdlContentUnitBuilder contentUnitBuilder;

        public DdlContentUnitCollectionBuilder(DdlContentUnitBuilder contentUnitBuilder)
        {
            this.contentUnitBuilder = contentUnitBuilder;
        }

        public Result<IReadOnlyList<ContentUnit>> BuildCollection(IEnumerable<AstContentUnit> astContentUnits)
        {
            var contentUnits = new List<ContentUnit>();

            foreach (var contentUnit in astContentUnits)
            {
                var result = this.contentUnitBuilder.Build(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                contentUnits.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<ContentUnit>>(contentUnits);
        }
    }
}
