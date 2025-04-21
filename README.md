

#### ConselUI SET AS STARTUP PROJECT RUN
***
### Nexum.MarsRover.Core

**Amaç:** Uygulamanın çekirdeğini oluşturur. Domain nesneleri, kurallar, arayüzler ve sabit tanımlar burada bulunur.
 **Bu katman hiçbir katmana bağımlı değildir.** En düşük bağımlılık seviyesine sahiptir.

---

### 2. Nexum.MarsRover.Business

 **Amaç:** Uygulamanın iş mantığını ve servislerini içerir. Komutları yorumlar, rover’ı hareket ettirir.

#### Sorumluluklar:
- Komutların çözümlenmesi (`CommandParser`)
- Rover’ın yön değiştirme, hareket etme mantığı
- Validasyonlar ve iş kuralları

 `Core` katmanındaki arayüzleri kullanarak uygulama mantığını gerçekler.

---

### 3. Nexum.MarsRover.ConsoleUI

 **Amaç:** Kullanıcı ile etkileşimin sağlandığı katmandır. Giriş/çıkış işlemleri burada yönetilir.

#### İçeriği:
- `Program.cs`: Konsol üzerinden veri alır, iş kurallarını tetikler, sonucu kullanıcıya gösterir.
- `Logs`: (Varsa) Loglama dosyaları burada tutulur.

 **UI katmanıdır. Diğer katmanlara bağımlıdır ancak onlara iş mantığı empoze etmez.**

---

--- Web veya mobil UI katmanları eklenebilir.
--- Loglama mail notif alış-veriş(rest) vs third party özellikler Infrascture katmanına eklenebilir.


#### ConselUI Set as startup project run