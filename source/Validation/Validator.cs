using DotNetCore.Objects;
using FluentValidation;

namespace DotNetCore.Validation
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        private string Message { get; set; }

        private string MessageForNull { get; set; }

        public IResult Valid(T instance)
        {
            if (instance == default)
            {
                return new ErrorResult(MessageForNull ?? Message ?? string.Empty);
            }

            var result = Validate(instance);

            if (result.IsValid)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Message ?? result.ToString());
        }

        public void WithMessage(string message)
        {
            Message = message;
        }

        public void WithMessageForNull(string message)
        {
            MessageForNull = message;
        }
    }
}
