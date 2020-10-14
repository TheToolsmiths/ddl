using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlParser
    {
        private readonly ILogger<DdlParser> log;
        private readonly IScopeContentParser parser;
        private readonly IParserContext parserContext;

        public DdlParser(ILogger<DdlParser> log, IParserContext parserContext, IScopeContentParser parser)
        {
            this.log = log;
            this.parserContext = parserContext;
            this.parser = parser;
        }

        public async Task<ContentUnitParseResult> ParseContentUnit(AstContentUnitInfo info)
        {
            var result = await this.ParseFileScopeContent(info);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var rootScope = result.Value;

            var fileContent = new AstContentUnit(info, rootScope);

            return ContentUnitParseResult.FromValue(fileContent);
        }

        private async Task<Result<AstContentUnitScope>> ParseFileScopeContent(AstContentUnitInfo info)
        {
            try
            {
                var result = await this.parser.ParseRootScopeContent(this.parserContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var value = new AstContentUnitScope(result.Value);

                return Result.FromValue(value);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                return Result.FromErrorMessage<AstContentUnitScope>(e.ToString());
            }
        }
    }
}
