using FluentValidation;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Business.Validations
{
    public class DeviceValidator : AbstractValidator<Device>
    {
        public DeviceValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Cihaz adı boş olamaz.")
                .MaximumLength(100).WithMessage("Cihaz adı en fazla 100 karakter olabilir.");

            RuleFor(d => d.SerialNumber)
                .NotEmpty().WithMessage("Seri numarası boş olamaz.")
                .MaximumLength(50).WithMessage("Seri numarası en fazla 50 karakter olabilir.");

            RuleFor(d => d.IPAddress)
                .Matches(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")
                .WithMessage("Geçerli bir IP adresi girin.");
        }
    }
}
