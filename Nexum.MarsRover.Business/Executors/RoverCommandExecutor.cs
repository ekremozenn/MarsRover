using Nexum.MarsRover.Core.Interfaces;

namespace Nexum.MarsRover.Business.Executors
{
    /// <summary>
    /// IRoverCommandExecutor arayüzünü implemente eden sınıf.
    /// Girilen komut dizisini IRover nesnesine uygular ve son durumu döndürür.
    /// </summary>
    public class RoverCommandExecutor : IRoverCommandExecutor
    {
        private readonly IRover _rover;
        private readonly ILogger _logger;

        /// <summary>
        /// </summary>
        /// <param name="rover">Komutları alacak rover nesnesi</param>
        /// <param name="logger">Loglama yapılacak servis</param>
        public RoverCommandExecutor(IRover rover, ILogger logger)
        {
            _rover = rover;
            _logger = logger;
        }

        /// <summary>
        /// Girilen komut dizisini sırayla işler.
        /// Her komut öncesi log kaydı oluşturur.
        /// </summary>
        /// <param name="commandInput">İşlenecek komut dizisi (örn: "LMLMRM")</param>
        public void ExecuteCommands(string commandInput)
        {
            foreach (char command in commandInput)
            {
                _logger.Log($"Komut çalıştırılıyor: {command}");
                _rover.Execute(command);
            }
        }

        /// <summary>
        /// Rover'ın anlık konum ve yön bilgisini string olarak döndürür.
        /// Format: "X Y Yön" (örn: "1 3 N")
        /// </summary>
        /// <returns>Rover'ın son durumu</returns>
        public string GetStatus()
        {
            return _rover.ToString();
        }
    }
}
