using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
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

        public Result<ContentUnit> BuildContentUnit(AstContentUnit astContentUnit)
        {
            return this.contentUnitBuilder.Build(astContentUnit);
        }
    }
}
