using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser
{
    public abstract class RootScopeParseResult : RootEntryParseResult
    {
        protected RootScopeParseResult(bool isSuccess)
            : base(isSuccess)
        {
        }

        public static ParserNotFoundRootScopeParseError CreateParserHandlerNotFound(
            IReadOnlyList<string> parserLookupIdentifiers)
        {
            return new ParserNotFoundRootScopeParseError(parserLookupIdentifiers);
        }

        public static RootScopeParseSuccess FromResult(IAstRootScope value)
        {
            return new RootScopeParseSuccess(value);
        }

        public static RootScopeParseError FromError(string errorMessage)
        {
            return new RootScopeParseError(errorMessage);
        }
    }

    public class ParserNotFoundRootScopeParseError : RootScopeParseError, IParserNotFoundParseError
    {
        internal ParserNotFoundRootScopeParseError(string errorMessage, IReadOnlyList<string> parserLookupIdentifiers)
            : base(errorMessage)
        {
            this.ParserLookupIdentifiers = parserLookupIdentifiers;
        }

        internal ParserNotFoundRootScopeParseError(IReadOnlyList<string> parserLookupIdentifiers)
        {
            this.ParserLookupIdentifiers = parserLookupIdentifiers;
        }

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }
    }

    public class RootScopeParseError : RootScopeParseResult
    {
        internal RootScopeParseError(string errorMessage)
            : base(false)
        {
            this.ErrorMessage = errorMessage;
        }

        protected RootScopeParseError()
            : base(false)
        {
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }
    }

    public class RootScopeParseSuccess : RootScopeParseResult
    {
        internal RootScopeParseSuccess(IAstRootScope value)
            : base(true)
        {
            this.Value = value;
        }

        public IAstRootScope Value { get; }
    }
}
