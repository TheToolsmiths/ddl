using System;

namespace TheToolsmiths.Ddl
{
    public class Result
    {
        private Result()
        {
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }

        private Result(string errorMessage)
        {
            this.IsSuccess = false;
            this.ErrorMessage = errorMessage;
        }

        public static Result Success { get; } = new Result();

        public static Result EmptyError { get; } = new Result(string.Empty);

        public string ErrorMessage { get; }

        public bool IsSuccess { get; }

        public bool IsError => this.IsSuccess == false;

        public static Result<T> FromValue<T>(T value)
            where T : class
        {
            return new Result<T>(value);
        }

        public static Result<T> FromException<T>(Exception exception)
            where T : class
        {
            return new Result<T>(exception.Message);
        }

        public static Result FromException(Exception exception)
        {
            return new Result(exception.Message);
        }

        public static Result<T> FromErrorMessage<T>(string errorMessage)
            where T : class
        {
            return new Result<T>(errorMessage);
        }

        public static Result FromErrorMessage(string errorMessage)
        {
            return new Result(errorMessage);
        }
    }
}
