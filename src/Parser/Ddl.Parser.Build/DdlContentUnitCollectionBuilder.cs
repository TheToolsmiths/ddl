using System;
using System.Collections.Generic;
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

        public Result BuildCollection(IEnumerable<AstContentUnit> contentUnits)
        {
            foreach (var contentUnit in contentUnits)
            {
                var result = this.contentUnitBuilder.Build(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
