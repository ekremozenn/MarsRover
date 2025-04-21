namespace Nexum.MarsRover.Business.InputModels
{
    /// <summary>
    /// Kullanıcıdan alınan rover giriş verilerini temsil eder.
    /// </summary>
    public class RoverInputModel
    {
        /// <summary>
        /// Mars yüzeyinin sağ üst koordinatlarını temsil eder.
        /// Format: "X Y" (örn: "5 5")
        /// </summary>
        public string PlateauInput { get; set; } = string.Empty;

        /// <summary>
        /// Rover'ın başlangıç pozisyonu ve yönü.
        /// Format: "X Y D" (örn: "1 2 N")
        /// </summary>
        public string StartPositionInput { get; set; } = string.Empty;

        /// <summary>
        /// Rover'a gönderilecek komut dizisi.
        /// Geçerli karakterler: L, R, M (örn: "LMLMLMLMM")
        /// </summary>
        public string CommandInput { get; set; } = string.Empty;
    }
}
