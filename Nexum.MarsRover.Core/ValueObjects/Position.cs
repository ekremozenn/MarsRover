namespace Nexum.MarsRover.Core.ValueObjects
{
    /// <summary>
    /// Rover'ın Mars yüzeyindeki X ve Y koordinatlarını temsil eder.
    /// Bu sınıf bir Value Object’tir. Değer değiştikçe yeni nesne oluşturulabilir.
    /// </summary>
    public class Position
    {
        #region Properties

        /// <summary>
        /// X ekseni üzerindeki koordinat.
        /// Get ve set özelliği vardır, dışarıdan da atanabilir.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y ekseni üzerindeki koordinat.
        /// Get ve set özelliği vardır, dışarıdan da atanabilir.
        /// </summary>
        public int Y { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Pozisyonu oluşturur (x, y).
        /// </summary>
        /// <param name="x">X koordinatı</param>
        /// <param name="y">Y koordinatı</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion
        #region ToString Override
        /// <summary>
        /// X ve Y koordinatlarını "X Y" formatında string olarak döndürür.
        /// </summary>
        /// <returns>Örn: "1 2"</returns>
        public override string ToString() => $"{X} {Y}";
        #endregion
    }
}
