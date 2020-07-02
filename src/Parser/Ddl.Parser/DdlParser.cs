﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlParser
    {
        private readonly ILogger<DdlParser> log;
        private readonly IScopeContentParser parser;
        private readonly IParserContext parserContext;

        public DdlParser(
            ILogger<DdlParser> log,
            IParserContext parserContext,
            IScopeContentParser parser)
        {
            this.log = log;
            this.parserContext = parserContext;
            this.parser = parser;
        }

        public async Task<ContentUnitParseResult> ParseContentUnit(ContentUnitInfo info)
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

        private async Task<Result<IAstRootScope>> ParseFileScopeContent(ContentUnitInfo info)
        {
            try
            {
                var result = await this.parser.ParseRootScopeContent(this.parserContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var value = new AstRootScope(result.Value);

                return Result.FromValue<IAstRootScope>(value);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                return Result.FromErrorMessage<IAstRootScope>(e.ToString());
            }
        }
    }
}
