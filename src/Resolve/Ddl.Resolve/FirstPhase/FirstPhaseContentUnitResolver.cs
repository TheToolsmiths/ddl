using System;
using System.Collections.Generic;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class FirstPhaseContentUnitResolver
    {
        private readonly FirstPhaseContentUnitCollectionResolver contentUnitResolver;
        private readonly FirstPhaseContentUnitTypeIndexer typeIndexer;

        public FirstPhaseContentUnitResolver(
            FirstPhaseContentUnitTypeIndexer typeIndexer,
            FirstPhaseContentUnitCollectionResolver contentUnitResolver)
        {
            this.typeIndexer = typeIndexer;
            this.contentUnitResolver = contentUnitResolver;
        }

        public Result<FirstPhaseResolvedContent> ResolveContentUnits(IReadOnlyList<ContentUnit> contentUnits)
        {
            var context = new ContentUnitsCollectionResolveContext();

            {
                var result = this.contentUnitResolver.ResolveContentUnits(context, contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = this.IndexTypes(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var content = new FirstPhaseResolvedContent(context.IndexedTypes, context.ContentUnits);
            
            return Result.FromValue(content);
        }

        private Result IndexTypes(ContentUnitsCollectionResolveContext context)
        {
            var result = this.typeIndexer.IndexTypes(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }
    }
}
