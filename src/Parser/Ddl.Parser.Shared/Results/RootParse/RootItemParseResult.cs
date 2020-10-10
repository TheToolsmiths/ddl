using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser
{
    public abstract class RootItemParseResult : RootEntryParseResult
    {
        protected RootItemParseResult(bool isSuccess)
            : base(isSuccess)
        {
        }

        public static ParserNotFoundRootItemParseError CreateParserHandlerNotFound(
            IReadOnlyList<string> parserLookupIdentifiers)
        {
            return new ParserNotFoundRootItemParseError(parserLookupIdentifiers);
        }

        public static RootItemParseSuccess FromResult(IAstRootItem value)
        {
            return new RootItemParseSuccess(value);
        }

        public static RootItemParseError FromError(string errorMessage)
        {
            return new RootItemParseError(errorMessage);
        }
    }

    public class ParserNotFoundRootItemParseError : RootItemParseError, IParserNotFoundParseError
    {
        internal ParserNotFoundRootItemParseError(string errorMessage, IReadOnlyList<string> parserLookupIdentifiers)
            : base(errorMessage)
        {
            this.ParserLookupIdentifiers = parserLookupIdentifiers;
        }

        internal ParserNotFoundRootItemParseError(IReadOnlyList<string> parserLookupIdentifiers)
        {
            this.ParserLookupIdentifiers = parserLookupIdentifiers;
        }

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }
    }

    public class RootItemParseError : RootItemParseResult
    {
        internal RootItemParseError(string errorMessage)
            : base(false)
        {
            this.ErrorMessage = errorMessage;
        }

        protected RootItemParseError()
            : base(false)
        {
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }
    }

    public class RootItemParseSuccess : RootItemParseResult
    {
        internal RootItemParseSuccess(IAstRootItem value)
            : base(true)
        {
            this.Value = value;
        }

        public IAstRootItem Value { get; }
    }
}
