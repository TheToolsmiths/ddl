using System;

namespace TheToolsmiths.Ddl
{
    public class ResultError
    {
        private ResultError(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public static ResultError FromException(Exception exception)
        {
            return new ResultError(exception.Message);
        }

        public static ResultError FromErrorMessage(string errorMessage)
        {
            return new ResultError(errorMessage);
        }
    }
}
