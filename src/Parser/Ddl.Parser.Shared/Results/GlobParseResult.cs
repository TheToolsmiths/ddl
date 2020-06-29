using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser
{
    public class GlobParseResult
    {
        private GlobParseResult(
            IReadOnlyList<AstContentUnit> contents,
            IReadOnlyList<ResultError> errors,
            in bool isSuccess,
            in bool hasErrors,
            in bool isEmpty)
        {
            this.Contents = contents;
            this.Errors = errors;
            this.IsSuccess = isSuccess;
            this.HasErrors = hasErrors;
            this.IsEmpty = isEmpty;
        }

        public bool IsAbsoluteSuccess => this.IsEmpty == false && this.IsSuccess && this.HasErrors == false;

        public bool IsSuccess { get; }

        public bool HasErrors { get; }

        public bool IsEmpty { get; }

        public IReadOnlyList<AstContentUnit> Contents { get; }

        public IReadOnlyList<ResultError> Errors { get; }

        public static GlobParseResult FromResults(
            IEnumerable<AstContentUnit> contents,
            IEnumerable<ResultError> errors)
        {
            var contentsList = contents.ToList();

            var errorsList = errors.ToList();

            bool isSuccess = contentsList.Any();

            bool hasErrors = errorsList.Any();

            bool isEmpty = isSuccess == false && hasErrors == false;

            return new GlobParseResult(contentsList, errorsList, isSuccess, hasErrors, isEmpty);
        }
    }
}
