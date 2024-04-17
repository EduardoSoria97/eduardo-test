using Application.Commands;
using Domain;
using Domain.Services;
using FluentValidation;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly UserRepository _userRepository;
        private readonly IValidator<User> _userValidator;

        public CreateUserCommandHandler(UserRepository userRepository, IValidator<User> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public void Handle(CreateUserCommand command)
        {
            var user = new User
            {
                Id = IdGenerator.GenerateUniqueId(),
                Name = command.Name,
                LastName = command.LastName,
                Email = command.Email,
                DNI = command.DNI,

            };

            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _userRepository.SaveUser(user);
            command.Id = user.Id;
        }
    }
}
