using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Los apellidos son obligatorios.");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("El email debe ser válido.");
            RuleFor(user => user.DNI).NotEmpty().Must(ValidateDNI).WithMessage("El DNI no es válido.");
        }
        public bool ValidateDNI(string dni)
        {
            return dni.Length == 9 && char.IsLetter(dni[8]);
        }

    }
}
