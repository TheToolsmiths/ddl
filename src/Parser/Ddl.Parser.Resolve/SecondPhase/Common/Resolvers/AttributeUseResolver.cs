using System;
using System.Collections.Generic;

using Ddl.Common;

using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.Common.Resolvers
{
    public class AttributeUseResolver
    {
        public Result<IReadOnlyList<IAttributeUse>> ResolveList(
            ScopeItemResolveContext context,
            IReadOnlyList<Parser.Ast.Models.AttributeUsage.IAttributeUse> astAttributes)
        {
            var attributes = new List<IAttributeUse>();

            foreach (var astAttribute in astAttributes)
            {
                var result = this.Resolve(context, astAttribute);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<IAttributeUse>>(attributes);
        }

        public Result<IAttributeUse> Resolve(
            ScopeItemResolveContext context,
            Parser.Ast.Models.AttributeUsage.IAttributeUse astAttributes)
        {
            throw new NotImplementedException();
        }
    }
}
