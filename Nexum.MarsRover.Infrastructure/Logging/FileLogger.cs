using Nexum.MarsRover.Core.Interfaces;

namespace Nexum.MarsRover.Infrastructure.Logging
{
    /// <summary>
    /// ILogger arayüzünü dosyaya loglama yapan şekilde implemente eden sınıf.
    /// Log dosyasını proje içindeki Logs klasörüne yazar.
    /// </summary>
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        #region Constructor - Log Dosyasını Oluşturma
        public FileLogger()
        {
            try
            {
                // Projenin kök dizinini bulması için
                string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\.."));

                // Log klasörü: Nexum.MarsRover.ConsoleUI\Logs
                string logDirectory = Path.Combine(projectRoot, "Nexum.MarsRover.ConsoleUI", "Logs");

                //  Eğer klasör yoksa oluştur
                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory);

                // Log dosyasının tam yolu
                _logFilePath = Path.Combine(logDirectory, "MarsRoverLog.txt");

                //  Dosya yoksa oluştur, sıfırlama yok — append modunda devam eder
                if (!File.Exists(_logFilePath))
                    File.Create(_logFilePath).Dispose(); // .Dispose() → dosya lock olmasın diye File.AppendAllText() açar
            }
            catch (Exception ex)
            {
                // Logger hata verirse console yazması için hata için try catch kullanılmıştır.
                Console.WriteLine($"[Logger Init Error] {ex.Message}");
                throw;
            }
        }
        #endregion
        #region Public Log Metotları
        /// <summary>
        /// Bilgi logu yazar (INFO seviyesinde)
        /// </summary>
        public void Log(string message)
        {
            WriteLog("INFO", message);
        }

        /// <summary>
        /// Hata logu yazar (ERROR seviyesinde)
        /// </summary>
        public void LogError(string message)
        {
            WriteLog("ERROR", message);
        }

        #endregion
        #region Özelleştirilmis Loglama Metodu
        /// <summary>
        /// Seviyeye göre timestamp ile birlikte dosyaya log yazar
        /// </summary>
        private void WriteLog(string level, string message)
        {
            try
            {
                // ISO 8601 formatlı timestamp örn: 2025-04-21T16:15:30.123Z
                string timestamp = DateTime.UtcNow.ToString("o");
                string logLine = $"[{timestamp}] [{level}] {message}";

                // Dosyaya ekle
                File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                //Log sırasında hata olursa bile program çökmesin
                Console.WriteLine($"[Log Write Error] {ex.Message}");
            }
        }
        #endregion
    }
}