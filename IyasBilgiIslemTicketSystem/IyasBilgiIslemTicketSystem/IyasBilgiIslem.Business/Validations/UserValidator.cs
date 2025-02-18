using FluentValidation;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Business.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");
        }
    }
}
