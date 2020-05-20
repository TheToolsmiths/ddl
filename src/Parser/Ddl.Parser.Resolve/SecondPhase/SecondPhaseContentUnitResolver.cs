using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    internal class SecondPhaseContentUnitResolver
    {
        private readonly SecondPhaseContentUnitItemsResolver contentUnitResolver;

        public SecondPhaseContentUnitResolver(SecondPhaseContentUnitItemsResolver contentUnitResolver)
        {
            this.contentUnitResolver = contentUnitResolver;
        }

        public Result ResolveContentUnit(FirstPhaseResolvedContentUnit firstPhaseContent)
        {
            var context = new ContentUnitResolveContext();

            {
                var result = this.contentUnitResolver.ResolveContentUnit(context, firstPhaseContent);

                if (result.IsError)
                {
                    throw new System.NotImplementedException();
                }
            }

            throw new System.NotImplementedException();
        }
    }
}
