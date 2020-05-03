using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Resolve.FirstPhase;
using TheToolsmiths.Ddl.Resolve.SecondPhase;

namespace TheToolsmiths.Ddl.Resolve
{
    public class DdlContentUnitsResolver
    {
        private readonly FirstPhaseContentUnitResolver firstPhaseResolver;
        private readonly SecondPhaseContentUnitResolver secondPhaseResolver;

        public DdlContentUnitsResolver(
            FirstPhaseContentUnitResolver firstPhaseResolver,
            SecondPhaseContentUnitResolver secondPhaseResolver)
        {
            this.firstPhaseResolver = firstPhaseResolver;
            this.secondPhaseResolver = secondPhaseResolver;
        }

        public Result ResolveContentUnits(IReadOnlyList<ContentUnit> contentUnits)
        {
            FirstPhaseResolvedContent firstPhaseContent;
            {
                var result = this.firstPhaseResolver.ResolveContentUnits(contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                firstPhaseContent = result.Value;
            }

            {
                var result = this.secondPhaseResolver.ResolveContentUnits(firstPhaseContent);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
