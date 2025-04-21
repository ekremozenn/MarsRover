using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Nexum.MarsRover.Business.Executors;
using Nexum.MarsRover.Business.InputModels;
using Nexum.MarsRover.Business.Services;
using Nexum.MarsRover.Business.Validators;
using Nexum.MarsRover.Core.Interfaces;
using System;

namespace Nexum.MarsRover.Business.DependencyInjection
{
    /// <summary>
    /// Business katmanındaki bağımlılıkları IoC konteynerine eklemek için kullanılan servis kayıt sınıfı.
    /// </summary>
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RoverInputModel>, RoverInputModelValidator>();
            services.AddTransient<IRoverCommandExecutor, RoverCommandExecutor>();//her Rover için yeni bir executor yaratılıyor:
            services.AddScoped<MissionControlService>();
            return services;
        }
    }
}