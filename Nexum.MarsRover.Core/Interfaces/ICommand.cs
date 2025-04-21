using System;

namespace Nexum.MarsRover.Core.Interfaces
{
    /// <summary>
    /// Komut Tasarım Deseni (Command Design Pattern) kapsamında kullanılan arayüzdür.
    /// Her bir komut sınıfı bu arayüzü uygulayarak IRover üzerinde belirli bir işlem gerçekleştirir.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Komutu belirtilen rover üzerinde çalıştırır.
        /// </summary>
        /// <param name="rover">Hedef rover nesnesi</param>
        void Execute(IRover rover);
    }
}
