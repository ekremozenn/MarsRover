namespace Nexum.MarsRover.Core.Interfaces
{
    /// <summary>
    /// Bir Mars Rover'ın aldığı komut dizisini işleyerek rover üzerinde uygular.
    /// Komutları sırasıyla çalıştırır ve rover'ın son konumunu (X Y Yön) verir.
    /// </summary>
    public interface IRoverCommandExecutor
    {
        #region ExecuteCommands

        /// <summary>
        /// Verilen komut dizisini rover üzerinde sırasıyla çalıştırır.
        /// Komutlar: 'L' (sola dön), 'R' (sağa dön), 'M' (ilerle)
        /// </summary>
        /// <param name="commandInput">Uygulanacak komut stringi, örn: "LMLMRM"</param>
        void ExecuteCommands(string commandInput);

        #endregion

        #region GetStatus

        /// <summary>
        /// Rover'ın mevcut pozisyon ve yön bilgisini string olarak döndürür.
        /// Format: "X Y Yön" (örnek: "1 3 N")
        /// </summary>
        /// <returns>Rover'ın son durumu</returns>
        string GetStatus();

        #endregion
    }
}
