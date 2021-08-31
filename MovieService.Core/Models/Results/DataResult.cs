namespace MovieService.Core.Models.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult() : base(true)
        {

        }

        public T Data { get; set; }
    }
}
