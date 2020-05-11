using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Ddl.Common;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlParser
    {
        private readonly IDdlLexer lexer;
        private readonly ILogger<DdlParser> log;
        private readonly IRootScopeContentParser rootParser;
        private readonly IParserContext parserContext;

        public DdlParser(
            ILogger<DdlParser> log,
            IDdlLexer lexer,
            IParserContext parserContext,
            IRootScopeContentParser rootParser)
        {
            this.log = log;
            this.lexer = lexer;
            this.parserContext = parserContext;
            this.rootParser = rootParser;
        }

        public async Task<ContentUnitParseResult> ParseContentUnit(ContentUnitInfo info)
        {
            var result = await this.ParseFileScopeContent(info);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var rootScope = result.Value;

            var fileContent = new ContentUnit(info, rootScope);

            return ContentUnitParseResult.FromValue(fileContent);
        }

        // TODO: Refactor into IFileRootScopeContentParser and Delete
        //private async Task<Result<IFileRootScope>> ParseRootScope(ContentUnitInfo info)
        //{

        //    while (this.lexer.HasNextToken)
        //    {
        //        if (await this.lexer.TryParseTokens() == false)
        //        {
        //            break;
        //        }

        //        var result = await this.ParseFileScopeContent();

        //        if (result.IsError)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        items.Add(result.Value);
        //    }

        //    var value = new FileRootScope();

        //    return Result.FromValue<IFileRootScope>(value);
        //}

        private async Task<Result<IFileRootScope>> ParseFileScopeContent(ContentUnitInfo info)
        {
            try
            {
                var result = await this.rootParser.ParseRootScopeContent(this.parserContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var value = new FileRootScope(result.Value);

                return Result.FromValue<IFileRootScope>(value);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                return Result.FromErrorMessage<IFileRootScope>(e.ToString());
            }
        }
    }
}
