using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ValueInitializationVisitor : BaseVisitor<ValueInitialization>
    {
        public override ValueInitialization VisitValueInitialization(DdlParser.ValueInitializationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
