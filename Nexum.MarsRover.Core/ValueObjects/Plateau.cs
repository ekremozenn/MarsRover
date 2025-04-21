namespace Nexum.MarsRover.Core.ValueObjects
{
    /// <summary>
    /// Mars yüzeyini temsil eden sınıf. 
    /// Sol alt köşe sabit olarak (0,0), sağ üst köşe ise MaxX, MaxY ile tanımlanır.
    /// </summary>
    public class Plateau
    {
        #region Properties
        /// <summary>
        /// Yüzeyin X eksenindeki maksimum koordinatı (sağ üst köşe)
        /// </summary>
        public int MaxX { get; } // Sadece okunabilir

        /// <summary>
        /// Yüzeyin Y eksenindeki maksimum koordinatı (sağ üst köşe)
        /// </summary>
        public int MaxY { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Plateau (yüzey) nesnesi oluşturur.
        /// </summary>
        /// <param name="maxX">X ekseni sınırı (0'dan büyük)</param>
        /// <param name="maxY">Y ekseni sınırı (0'dan büyük)</param>
        public Plateau(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        #endregion

        #region Clamp Method

        /// <summary>
        /// Verilen pozisyon eğer sınırların dışındaysa, sınırlar içinde kalacak şekilde "kırpılır".
        /// Örn: (7,4) → (5,4) gibi
        /// </summary>
        /// <param name="position">Gidilmek istenen pozisyon</param>
        /// <returns>Sınırların içinde tutulmuş pozisyon</returns>
        public Position Clamp(Position position)
        {
            int x = Math.Max(0, Math.Min(position.X, MaxX));
            int y = Math.Max(0, Math.Min(position.Y, MaxY));
            return new Position(x, y);
        }

        #endregion
    }
}
