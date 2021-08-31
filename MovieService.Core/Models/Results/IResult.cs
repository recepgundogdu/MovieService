namespace MovieService.Core.Models.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
