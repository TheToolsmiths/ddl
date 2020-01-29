using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Arrays;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FixedArrayDimensionsDefinitionVisitor : BaseVisitor<FixedArraySize>
    {
        public override FixedArraySize VisitFixedSizeDefinition(DdlParser.FixedSizeDefinitionContext context)
        {
            if (context.IntLiteral().Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(context));
            }

            var dimensions = new List<string>();
            foreach (var node in context.IntLiteral())
            {
                string dimension = LiteralParsers.ParseIntegerLiteralValue(node);

                dimensions.Add(dimension);
            }

            return new FixedArraySize(dimensions);
        }
    }
}
