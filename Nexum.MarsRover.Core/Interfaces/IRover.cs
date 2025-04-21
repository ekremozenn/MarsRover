using Nexum.MarsRover.Core.ValueObjects;
using Nexum.MarsRover.Core.Enums;

namespace Nexum.MarsRover.Core.Interfaces
{
    /// <summary>
    /// Bir Mars Rover'ın sahip olması gereken temel özellik ve davranışları tanımlayan arayüzdür.
    /// Pozisyon, yön ve komutlara tepki verme davranışlarını içerir.
    /// </summary>
    public interface IRover
    {
        #region Properties

        /// <summary>
        /// Rover'ın mevcut pozisyonudur (X,Y koordinatları).
        /// </summary>
        Position Position { get; }

        /// <summary>
        /// Rover'ın baktığı yön (North, East, South, West).
        /// </summary>
        Direction Direction { get; }

        #endregion

        #region Movement Methods

        /// <summary>
        /// Rover'ı mevcut konumunda 90 derece sola çevirir.
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Rover'ı mevcut konumunda 90 derece sağa çevirir.
        /// </summary>
        void TurnRight();

        /// <summary>
        /// Rover'ı yöneldiği yöne doğru bir birim ilerletir.
        /// </summary>
        void Move();

        #endregion

        #region Command Execution

        /// <summary>
        /// Tek bir komutu çalıştırır. (L, R veya M)
        /// 'L' → sola dön, 'R' → sağa dön, 'M' → ilerle.
        /// </summary>
        /// <param name="command">Komut karakteri</param>
        void Execute(char command);

        #endregion
    }
}
