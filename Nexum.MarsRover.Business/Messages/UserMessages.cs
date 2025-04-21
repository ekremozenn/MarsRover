namespace Nexum.MarsRover.Business.Messages
{
    public static class UserMessages
    {
        public const string AskPlateau = "Mars yüzeyinin sağ üst koordinatlarını girin (örn: 5 5):";
        public const string AskStartPosition = "Rover {0} için başlangıç pozisyonunu girin (örn: 1 2 N):";
        public const string AskCommandInput = "Rover {0} için komutları girin (örn: LMLMLMLMM):";
        public const string InvalidDirection = "Geçersiz yön girdiniz: {0} (Sadece N, E, S, W olmalı)";
        public const string MissionComplete = "Tüm rover işlemleri başarıyla tamamlandı. Mars Görevi sona erdi.";
        public const string RoverCommandStart = "Rover {0} komutları çalıştırılıyor...";
        public const string RoverFinalStatus = "Rover {0} Son Konumu: {1}";
        public const string ValidationHeader = "Rover {0} için hatalı giriş yapıldı:";
        public const string ValidationError = "[VALIDATION] {0}";
        //birden fazla dil
    }
}
