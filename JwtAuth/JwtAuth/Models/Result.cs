using System;

namespace Movies.Api.Models
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public string Error { get; private set; }
        public bool IsSuccess => Error == null;

        public static Result<T> Success(T value) => new Result<T> { Value = value };
        public static Result<T> Failure(string error) => new Result<T> { Error = error };
    }

    public class Result
    {
        public string Error { get; private set; }
        public bool IsSuccess => Error == null;

        public static Result Success() => new Result();
        public static Result Failure(string error) => new Result { Error = error };
    }
}
