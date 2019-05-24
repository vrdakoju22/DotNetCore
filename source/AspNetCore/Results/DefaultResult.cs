using DotNetCore.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCore.AspNetCore
{
    public class DefaultResult : IActionResult
    {
        public DefaultResult(IResult result)
        {
            Result = result;
        }

        private IResult Result { get; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            object value = default;

            if (!Result.Success)
            {
                value = Result.Message;
            }
            else if
            (
                Result.GetType().IsGenericType &&
                (
                    Result.GetType().GetGenericTypeDefinition() == typeof(SuccessDataResult<>) ||
                    Result.GetType().GetGenericTypeDefinition() == typeof(ErrorDataResult<>) ||
                    Result.GetType().GetGenericTypeDefinition() == typeof(DataResult<>)
                )
            )
            {
                value = (Result as dynamic).Data;
            }

            var objectResult = new ObjectResult(value)
            {
                StatusCode = Result.Success ? StatusCodes.Status200OK : StatusCodes.Status422UnprocessableEntity
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
