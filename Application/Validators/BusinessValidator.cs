using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class BusinessValidator : AbstractValidator<Business>
    {
        public BusinessValidator() 
        {
            RuleFor(business => business.BusinessName).NotEmpty().WithMessage("El nombre del negocio es obligatorio.");
            RuleFor(business => business.CIF).NotEmpty().Must(ValidateCIF).WithMessage("El CIF no es válido.");
            RuleFor(business => business.Address).NotEmpty().WithMessage("La dirección es obligatoria.");
            RuleFor(business => business.Phone).NotEmpty().Must(ValidatePhone).WithMessage("El teléfono no es válido.");

        }

        public bool ValidateCIF(string cif)
        {
            return cif.Length == 9 && char.IsLetter(cif[8]);
        }

        public bool ValidatePhone(string phone)
        {
            return phone.Length >= 9 && phone.All(char.IsDigit);
        }
    }
}
