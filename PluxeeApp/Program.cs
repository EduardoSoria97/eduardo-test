using Application.Commands;
using Application.Handlers;
using Application.Validators;
using Domain;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

class Program
{
    static void Main(string[] args)
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        var userCommandHandler = serviceProvider.GetRequiredService<ICommandHandler<CreateUserCommand>>();
        var businessCommandHandler = serviceProvider.GetRequiredService<ICommandHandler<CreateBusinessCommand>>();

        //User
        var userCommand = new CreateUserCommand
        {
            Name = Prompt("Introduce el nombre del usuario:"),
            LastName = Prompt("Introduce los apellidos del usuario:"),
            Email = Prompt("Introduce el email del usuario:"),
            DNI = Prompt("Introduce el DNI del usuario:")
        };

        try
        {
            userCommandHandler.Handle(userCommand);
            Console.WriteLine("Usuario creado corectamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el usuario: {ex.Message}");
            return;
        }

        //Business
        var businessCommand = new CreateBusinessCommand
        {
            UserId = userCommand.Id,
            BusinessName = Prompt("Introduce el nombre del negocio:"),
            CIF = Prompt("Introduce el CIF del negocio:"),
            Address = Prompt("Introduce la dirección del negocio:"),
            Phone = Prompt("Introduce el teléfono del negocio:")
        };

        try
        {
            businessCommandHandler.Handle(businessCommand);
            Console.WriteLine("Negocio creado con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el negocio: {ex.Message}");
        }
    }

    static string Prompt(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
        services.AddTransient<ICommandHandler<CreateBusinessCommand>, CreateBusinessCommandHandler>();
        services.AddTransient<IValidator<User>, UserValidator>();
        services.AddTransient<IValidator<Business>, BusinessValidator>();
        services.AddTransient<UserRepository>();
        services.AddTransient<BusinessRepository>();

        return services;
    }
}