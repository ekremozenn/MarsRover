namespace Nexum.MarsRover.Business.Messages
{
    /// <summary>
    /// FluentValidation mesajları buradan yönetilsin.
    /// </summary>
    /// //2 class yerine regionlarla ayrılabilridi
    public static class ValidationMessages
    {
        public const string Plateau_Empty = "Mars yüzeyi boş olamaz.";
        public const string Plateau_Format = "Geçerli bir format girin. Doğru format: 'X Y' (örn: 5 5)";

        public const string Start_Empty = "Başlangıç pozisyonu boş olamaz.";
        public const string Start_Format = "Format hatalı. Doğru format: 'X Y Yön' (örn: 1 2 N)";
        public const string Start_InvalidDirection = "Geçersiz yön girdiniz: {0}. Sadece N, E, S, W kabul edilir.";

        public const string Command_Empty = "Komutlar boş olamaz.";
        public const string Command_Format = "Sadece L, R ve M harflerinden oluşmalı. Örn: LMLMLMLMM";
    }
}
