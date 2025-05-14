using Application.IServices;
using Application.Mappers;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;


namespace Application;

public static class ApplicationServiceExtension
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        /* Third Party Libraries */
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();        
        services.AddFluentValidationAutoValidation();
        
        // Project Dependencies
        services.AddTransient<IUserService, UserService>();
    }
}