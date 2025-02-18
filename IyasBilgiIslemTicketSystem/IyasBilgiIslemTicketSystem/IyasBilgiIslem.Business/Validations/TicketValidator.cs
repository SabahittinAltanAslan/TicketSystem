using FluentValidation;
using IyasBilgiIslem.Core.Entities;
namespace IyasBilgiIslem.Business.Validations
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(255).WithMessage("Başlık en fazla 255 karakter olabilir.");

            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.");

            RuleFor(t => t.BranchId)
                .GreaterThan(0).WithMessage("Şube ID geçerli olmalıdır.");

            RuleFor(t => t.CategoryId)
                .GreaterThan(0).WithMessage("Kategori seçilmelidir.");
        }
    }
}
