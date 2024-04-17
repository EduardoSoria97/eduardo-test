using Application.Commands;
using Domain;
using FluentValidation;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateBusinessCommandHandler : ICommandHandler<CreateBusinessCommand>
    {
        private readonly BusinessRepository _businessRepository;
        private readonly IValidator<Business> _businessValidator;

        public CreateBusinessCommandHandler(BusinessRepository businessRepository, IValidator<Business> businessValidator)
        {
            _businessRepository = businessRepository;
            _businessValidator = businessValidator;
        }

        public void Handle(CreateBusinessCommand command)
        {
            var business = new Business
            {
                UserId = command.UserId,
                BusinessName = command.BusinessName,
                CIF = command.CIF,
                Address = command.Address,
                Phone = command.Phone
            };

            var validationResult = _businessValidator.Validate(business);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _businessRepository.SaveBusiness(business, business.UserId);
        }
    }
}
