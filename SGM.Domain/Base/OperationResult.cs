namespace SGM.Domain.Base
{
    public class OperationResult <T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string[] Errors { get; set; }
        public static OperationResult<T> Success(T value) => new OperationResult<T> { IsSuccess = true, Value = value };
        public static OperationResult<T> Fail(string[] errors) => new OperationResult<T> { IsSuccess = false, Errors = errors };
    }
}
