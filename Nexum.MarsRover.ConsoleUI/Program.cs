using Microsoft.Extensions.DependencyInjection;
using Nexum.MarsRover.Business.DependencyInjection;
using Nexum.MarsRover.Business.Services;
using Nexum.MarsRover.Infrastructure.DependencyInjection;

namespace Nexum.MarsRover.ConsoleUI
{
    /// <summary>
    /// Uygulamanın giriş noktası. Servisleri başlatır ve görevi çalıştırır.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Service Configuration

            // IoC container oluşturuluyor (bağımlılıkları çözmek için)
            var services = new ServiceCollection();

            // Business katmanındaki servisler
            services.AddBusinessServices();

            // Infrastructure katmanındaki servisler
            services.AddInfrastructureServices();

            #endregion

            #region Service Provider & Görev Başlatma

            var provider = services.BuildServiceProvider();

            var missionControl = provider.GetRequiredService<MissionControlService>();

            // Mars görevini çalıştır
            missionControl.Run();

            #endregion
        }
    }
}