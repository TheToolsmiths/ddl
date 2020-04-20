using System;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ReferenceTypePrefixVisitor : BaseVisitor<ReferenceKind>
    {
        public override ReferenceKind VisitReferencePrefix(DdlParser.ReferencePrefixContext context)
        {
            if (context.refHandlePrefix() != null)
            {
                return ReferenceKind.Handle;
            }

            if (context.refOwnsPrefix() != null)
            {
                return ReferenceKind.Owns;
            }

            if (context.refReferencePrefix() != null)
            {
                return ReferenceKind.Reference;
            }

            throw new NotImplementedException();
        }
    }
}
