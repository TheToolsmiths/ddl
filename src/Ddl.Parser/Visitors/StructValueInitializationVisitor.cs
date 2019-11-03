using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructValueInitializationVisitor : BaseVisitor<StructValueInitialization>
    {
        public override StructValueInitialization VisitStructValueInitialization(
            DdlParser.StructValueInitializationContext context)
        {
            if (context == null)
            {
                return StructValueInitialization.CreateEmpty();
            }

            var initializations = new List<FieldValueInitialization>();
            foreach (var fieldContext in context.fieldValueInitialization())
            {
                var visitor = new FieldValueInitializationContext();
                var fieldInitialization = visitor.VisitFieldValueInitialization(fieldContext);

                initializations.Add(fieldInitialization);
            }

            return new StructValueInitialization(initializations);
        }
    }
}
