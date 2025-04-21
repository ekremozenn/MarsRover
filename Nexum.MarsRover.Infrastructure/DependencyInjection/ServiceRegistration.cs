using Microsoft.Extensions.DependencyInjection;
using Nexum.MarsRover.Core.Interfaces;
using Nexum.MarsRover.Infrastructure.Logging;

namespace Nexum.MarsRover.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Infrastructure katmanına ait servislerin bağımlılıklarını uygulamaya ekleyen sınıf.
    /// </summary>
    /// Program.cs daha temiz, her katmanı ayırdık.
    public static class ServiceRegistration
    {
        #region AddInfrastructureServices
        /// <summary>
        /// Infrastructure servislerini IoC container'a kaydeder.
        /// Örn: FileLogger → ILogger olarak tanımlanır.
        /// </summary>
        /// <param name="services">IoC container (ServiceCollection)</param>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Uygulama boyunca aynı logger kullanılacağı için singleton
            services.AddSingleton<ILogger, FileLogger>();

            return services;
        }
        #endregion
    }
}
