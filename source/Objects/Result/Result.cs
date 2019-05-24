using System.Threading.Tasks;

namespace DotNetCore.Objects
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public string Message { get; }

        public bool Success { get; }

        public Task<IResult> ToTask()
        {
            return Task.FromResult(this as IResult);
        }
    }
}
