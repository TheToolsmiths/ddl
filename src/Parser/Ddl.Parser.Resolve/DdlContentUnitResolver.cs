using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Resolve.FirstPhase;
using TheToolsmiths.Ddl.Resolve.SecondPhase;

namespace TheToolsmiths.Ddl.Resolve
{
    internal class DdlContentUnitResolver
    {
        private readonly FirstPhaseContentUnitResolver firstPhaseResolver;
        private readonly SecondPhaseContentUnitResolver secondPhaseResolver;

        public DdlContentUnitResolver(
            FirstPhaseContentUnitResolver firstPhaseResolver,
            SecondPhaseContentUnitResolver secondPhaseResolver)
        {
            this.firstPhaseResolver = firstPhaseResolver;
            this.secondPhaseResolver = secondPhaseResolver;
        }

        public Result ResolveContentUnit(ContentUnit contentUnit)
        {
            FirstPhaseResolvedContentUnit firstPhaseContent;
            {
                var result = this.firstPhaseResolver.ResolveContentUnit(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                firstPhaseContent = result.Value;
            }

            {
                var result = this.secondPhaseResolver.ResolveContentUnit(firstPhaseContent);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
