# 🌡️ Temperature Tracking Backend

Bu proje, **SignalR** ile gerçek zamanlı sıcaklık takibi yapan ve kritik sıcaklık aşımlarını **PostgreSQL**'e kaydeden **ASP.NET Core Web API** uygulamasıdır.

---

## 🏗️ Mimari ve Yaklaşımlar

* **Katmanlı Mimari (N-Tier):** Proje; Core, Infrastructure, Business ve API olmak üzere 4 katmanda kurgulanarak sorumlulukların ayrılması sağlanmıştır.
* **EF Core Code-First:** Veritabanı şeması C# sınıfları üzerinden tasarlanmış ve Migrations ile yönetilmektedir.
* **SignalR Hub:** Sunucuda üretilen veriler, WebSockets üzerinden frontend istemcisine anlık olarak iletilir.
* **TemperatureWorker (Worker Service):** Uygulama arka planında 5 saniyede bir otonom olarak sıcaklık üretir, eşik kontrolü yapar ve veriyi Hub üzerinden yayınlar.
* * **Dependency Injection:** Servis ömürleri (Scoped/Singleton) profesyonelce yönetilerek bağımlılık yönetimi optimize edilmiştir.

---

## 🗄️ Veritabanı Yönetimi

80°C üzerindeki tüm veriler PostgreSQL tarafında `AlarmLog` tablosunda saklanır.

<img width="500" alt="image" src="https://github.com/user-attachments/assets/79b48c2f-11b4-4aa7-9fa2-96860c37ea81" />

---

## 🚀 Kurulum ve Çalıştırma

1.  **Projeyi Klonlayın:**
    ```bash
    git clone [proje-url]
    ```
2.  **Bağımlılıkları Yükleyin:**
    ```bash
    dotnet restore
    ```
3.  **Veritabanı Yapılandırması:**
    `appsettings.json` içerisindeki `PostgreConnection` kısmını kendi yerel PostgreSQL bilgilerinizle güncelleyin:
    ```json
    "ConnectionStrings": {
      "PostgreConnection": "Host=localhost;Database=TempDb;Username=postgres;Password=sifre"
    }
    ```
4.  **Veritabanını Güncelleyin:**
    ```bash
    dotnet ef database update
    ```
5.  **Uygulamayı Çalıştırın:**
    ```bash
    dotnet run
    ```
    * API adresi: `http://localhost:5057`
