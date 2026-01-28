# 🌡️ Temperature Tracking Backend (SignalR API)

Bu proje, gerçek zamanlı sıcaklık verileri üreten ve bu verileri SignalR Hub üzerinden istemcilere (frontend) dağıtan bir ASP.NET Core Web API uygulamasıdır.

## 🛠️ Teknik Özellikler
- **SignalR Hub:** Gerçek zamanlı, çift yönlü veri iletişimi sağlar.
- **Background Worker:** `BackgroundService` sınıfı kullanılarak arka planda 5 saniyelik periyotlarla rastgele sıcaklık verisi üretilir.
- **CORS Yapılandırması:** Angular frontend uygulamasının (port 4200) güvenli bir şekilde bağlanmasına izin verir.
- **Alarm logu 80 dereceyi aştığında "kritik seviye" olarak veri tabanına kaydedilir.
- <img width="646" height="899" alt="image" src="https://github.com/user-attachments/assets/79b48c2f-11b4-4aa7-9fa2-96860c37ea81" />

## 🚀 Kurulum ve Çalıştırma
1. Projeyi klonlayın.
2. Terminalde proje ana dizinine gidin.
3. `dotnet restore` ile paketleri yükleyin.
4. `dotnet run` komutu ile uygulamayı başlatın.
   - API varsayılan olarak `http://localhost:5057` adresinde çalışacaktır.

