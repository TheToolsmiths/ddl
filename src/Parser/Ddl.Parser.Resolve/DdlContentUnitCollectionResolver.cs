using System;
using System.Collections.Generic;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Resolve
{
    internal class DdlContentUnitCollectionResolver : IDdlContentUnitCollectionResolver
    {
        private readonly DdlContentUnitResolver contentUnitResolver;
        public DdlContentUnitCollectionResolver(DdlContentUnitResolver contentUnitResolver)
        {
            this.contentUnitResolver = contentUnitResolver;
        }

        public Result ResolveContentUnits(IEnumerable<ContentUnit> contentUnits)
        {
            foreach (var contentUnit in contentUnits)
            {
                var result = this.contentUnitResolver.ResolveContentUnit(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
