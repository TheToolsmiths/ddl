﻿using System;

namespace Ddl.Common
{
    public class Result<T>
        where T : class
    {
        internal Result(T value)
        {
            this.Value = value;
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }

        internal Result(string errorMessage)
        {
            this.Value = default!;
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess { get; }

        public bool IsError => this.IsSuccess == false;

        public T Value { get; }

        public Result AsResult()
        {
            if (this.IsSuccess)
            {
                throw new NotImplementedException();
            }

            return Result.FromErrorMessage(this.ErrorMessage);
        }

        public Result<TResult> As<TResult>()
            where TResult : class
        {
            if (this.IsSuccess)
            {
                if (this.Value is TResult == false)
                {
                    throw new ArgumentException();
                }

                return Result.FromValue((this.Value as TResult)!);
            }

            return Result.FromErrorMessage<TResult>(this.ErrorMessage);
        }
    }
}
