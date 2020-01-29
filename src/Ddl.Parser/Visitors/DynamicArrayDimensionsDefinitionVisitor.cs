using TheToolsmiths.Ddl.Models.Arrays;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class DynamicArrayDimensionsDefinitionVisitor : BaseVisitor<DynamicArraySize>
    {
        public override DynamicArraySize VisitDynamicSizeDefinition(DdlParser.DynamicSizeDefinitionContext context)
        {
            return DynamicArraySize.Create();
        }
    }
}
