using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Arrays;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ArrayDimensionsDefinitionListVisitor : BaseVisitor<IReadOnlyList<ArraySize>>
    {
        public override IReadOnlyList<ArraySize> VisitArrayDimensionsDefinitions(DdlParser.ArrayDimensionsDefinitionsContext context)
        {
            var definitionContexts = context.arraySizeDefinition();

            if (definitionContexts.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(definitionContexts));
            }

            var visitor = new ArraySizeDefinitionVisitor();

            var definitions = new List<ArraySize>();
            foreach (var definitionContext in definitionContexts)
            {
                var definition = visitor.VisitArrayDimensions(definitionContext);

                definitions.Add(definition);
            }


            return definitions;
        }
    }
}
