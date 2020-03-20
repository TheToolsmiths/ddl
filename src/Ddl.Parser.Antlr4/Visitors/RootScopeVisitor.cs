using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class RootScopeVisitor : BaseVisitor<RootScope>
    {
        public override RootScope VisitRootScope(DdlParser.RootScopeContext context)
        {
            ConditionalExpression conditionalExpression;
            {
                var scopeHeaderContext = context.scopeHeader();

                var visitor = new ScopeHeaderVisitor();

                conditionalExpression = visitor.VisitScopeHeader(scopeHeaderContext);
            }

            IReadOnlyList<IRootContentItem> rootContentItems;
            {
                var contents = context.rootContentList();

                if (contents != null)
                {
                    var contentListContext = context.rootContentList();

                    var visitor = new RootContentListVisitor();

                    rootContentItems = visitor.VisitRootContentList(contentListContext);
                }
                else
                {
                    rootContentItems = Array.Empty<IRootContentItem>();
                }
            }

            return new RootScope(conditionalExpression, rootContentItems);
        }
    }
}
