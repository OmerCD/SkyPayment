using System.Linq;
using FluentValidation;
using SkyPayment.Contract.RequestModel.Authentication;

namespace SkyPayment.Client.API.Validators
{
    public class RegisterValidator : AbstractValidator<UserRegisterCreateModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(6, 12);
            RuleFor(x => x.FirstName).NotEmpty().Length(2, 20);
            RuleFor(x => x.LastName).NotEmpty().Length(2, 25);
            RuleFor(x => x.TelephoneNumber).Length(11).Custom((value, context) =>
            {
                if (value?.Any(char.IsDigit) != true)
                {
                    context.AddFailure("Telefon Numarası sadece sayılardan oluşmalı ve boş olmamalıdır.");
                }
            });
        }
    }
}