using System;
using TheToolsmiths.Ddl.Models.Arrays;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ArraySizeDefinitionVisitor : BaseVisitor<ArraySize>
    {
        public ArraySize VisitArrayDimensions(DdlParser.ArraySizeDefinitionContext context)
        {
            switch (context)
            {
                case DdlParser.DynamicSizeDefinitionContext dynamicSizeContext:
                    {
                        var visitor = new DynamicArrayDimensionsDefinitionVisitor();
                        return visitor.VisitDynamicSizeDefinition(dynamicSizeContext);
                    }

                case DdlParser.FixedSizeDefinitionContext fixedSizeContext:
                    {
                        var visitor = new FixedArrayDimensionsDefinitionVisitor();
                        return visitor.VisitFixedSizeDefinition(fixedSizeContext);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(context));
            }
        }
    }
}
