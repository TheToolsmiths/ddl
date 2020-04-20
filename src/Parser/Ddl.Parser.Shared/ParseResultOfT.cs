namespace TheToolsmiths.Ddl.Parser.Shared
{
    public class ParseResult<T>
        where T : class
    {
        public ParseResult(T value)
        {
            this.Value = value;
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }

        public ParseResult(string errorMessage)
        {
            this.Value = default!;
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess { get; }

        public bool IsError => this.IsSuccess == false;

        public T Value { get; }
    }
}
