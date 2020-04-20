using System;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class RootContentItemVisitor : BaseVisitor<IRootContentItem>
    {
        public override IRootContentItem VisitRootContent(DdlParser.RootContentContext context)
        {
            {
                var structContext = context.defStruct();

                if (structContext != null)
                {
                    var visitor = new StructDefinitionVisitor();

                    return visitor.VisitDefStruct(structContext);
                }
            }

            {
                var rootScopeContext = context.rootScope();

                if (rootScopeContext != null)
                {
                    var visitor = new RootScopeVisitor();

                    return visitor.VisitRootScope(rootScopeContext);
                }
            }

            throw new NotImplementedException();
        }
    }
}
