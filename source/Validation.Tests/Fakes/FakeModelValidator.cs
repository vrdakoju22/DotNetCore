using FluentValidation;

namespace DotNetCore.Validation.Tests
{
    public sealed class FakeModelValidator : Validator<FakeModel>
    {
        public FakeModelValidator()
        {
            WithMessageForNull("FakeModel is null.");
            WithMessage("FakeModel is invalid.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
