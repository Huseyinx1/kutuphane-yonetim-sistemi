# 📚 Kütüphane Yönetim Sistemi

Modern ve profesyonel bir kütüphane yönetim sistemi. ASP.NET Core MVC ve SQL Server kullanılarak geliştirilmiştir.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Express-blue)
![License](https://img.shields.io/badge/license-MIT-orange)

## ✨ Özellikler

### 📖 Kitap Yönetimi
- Kitap ekleme, düzenleme ve silme
- Kitap türlerine göre kategorilendirme
- ISBN, sayfa sayısı ve özet bilgileri
- Çoklu tür seçimi desteği

### 🏷️ Tür Yönetimi
- Kitap türleri ekleme ve yönetme
- Tür bazlı filtreleme ve arama

### 👥 Üye Yönetimi
- Üye kayıt ve güncelleme
- Üye aktiflik durumu takibi
- Üye bilgileri yönetimi

### 🔄 Ödünç İşlemleri
- Kitap ödünç verme
- Ödünç takip ve yönetim
- Geri getirme tarihi takibi
- Ödünç durumu kontrolü

## 🚀 Kurulum

### Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads) veya SQL Server
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [Visual Studio Code](https://code.visualstudio.com/)

### Adımlar

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/yourusername/kutuphane.git
   cd kutuphane
   ```

2. **Connection String'i yapılandırın**
   
   `appsettings.json` dosyasındaki connection string'i kendi SQL Server bilgilerinize göre güncelleyin:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=Kutuphane;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Veritabanını oluşturun**
   ```bash
   dotnet ef database update
   ```

4. **Uygulamayı çalıştırın**
   ```bash
   dotnet run
   ```

5. **Tarayıcıda açın**
   ```
   https://localhost:5001
   ```

## 📁 Proje Yapısı

```
kutuphane/
├── Controllers/          # MVC Controller'ları
│   ├── HomeController.cs
│   ├── TurController.cs
│   ├── KitapController.cs
│   ├── UyeController.cs
│   └── OduncController.cs
├── Models/              # Veri modelleri
│   ├── Tur.cs
│   ├── Kitap.cs
│   ├── Yazar.cs
│   ├── Uye.cs
│   ├── Odunc.cs
│   ├── KitapTur.cs
│   └── KitapYazar.cs
├── Views/               # Razor View'ları
│   ├── Home/
│   ├── Tur/
│   ├── Kitap/
│   ├── Uye/
│   └── Odunc/
├── Data/                # DbContext
│   └── KutuphaneDbContext.cs
├── wwwroot/             # Statik dosyalar
│   ├── css/
│   └── js/
└── Program.cs           # Uygulama giriş noktası
```

## 🗄️ Veritabanı Şeması

### Tablolar

- **tur** - Kitap türleri
- **Kitap** - Kitaplar
- **yazar** - Yazarlar
- **uye** - Üyeler
- **odunc** - Ödünç işlemleri
- **kitap_tur** - Kitap-Tür ilişki tablosu
- **kitap_yazar** - Kitap-Yazar ilişki tablosu

### İlişkiler

- Bir kitap birden fazla türe sahip olabilir (Many-to-Many)
- Bir kitap birden fazla yazara sahip olabilir (Many-to-Many)
- Bir üye birden fazla kitap ödünç alabilir (One-to-Many)
- Bir kitap birden fazla kez ödünç verilebilir (One-to-Many)

## 🎨 Tasarım Özellikleri

- ✨ Modern gradient arka plan animasyonları
- 🎭 Glassmorphism efektleri
- 🎯 Responsive tasarım
- 🎨 Profesyonel UI/UX
- ⚡ Smooth animasyonlar ve geçişler
- 🎪 Hover efektleri ve interaktif öğeler

## 🛠️ Teknolojiler

- **Backend:** ASP.NET Core 8.0 MVC
- **Veritabanı:** SQL Server
- **ORM:** Entity Framework Core 8.0
- **Frontend:** Bootstrap 5, HTML5, CSS3, JavaScript
- **Stil:** Custom CSS with modern design patterns

## 📝 Kullanım

### Kitap Türü Ekleme
1. Menüden "Kitap Türleri" seçeneğine tıklayın
2. "Yeni Tür Ekle" butonuna tıklayın
3. Tür açıklamasını girin ve kaydedin

### Kitap Ekleme
1. Menüden "Kitaplar" seçeneğine tıklayın
2. "Yeni Kitap Ekle" butonuna tıklayın
3. Kitap bilgilerini doldurun
4. İlgili türleri seçin ve kaydedin

### Üye Ekleme
1. Menüden "Üyeler" seçeneğine tıklayın
2. "Yeni Üye Ekle" butonuna tıklayın
3. Üye bilgilerini doldurun ve kaydedin

### Ödünç Verme
1. Menüden "Ödünç İşlemleri" seçeneğine tıklayın
2. "Yeni Ödünç Ver" butonuna tıklayın
3. Kitap ve üye seçin
4. Verme tarihi ve süresini belirleyin
5. Kaydedin

## 🔧 Geliştirme

### Migration Oluşturma
```bash
dotnet ef migrations add MigrationAdi
```

### Veritabanını Güncelleme
```bash
dotnet ef database update
```

### Migration Geri Alma
```bash
dotnet ef migrations remove
```

## 📸 Ekran Görüntüleri

### Ana Sayfa
Modern ve kullanıcı dostu ana sayfa tasarımı ile hızlı erişim kartları.
<img width="2559" height="1391" alt="image" src="https://github.com/user-attachments/assets/2576d316-2261-47bb-af64-dfc83b17a564" />


### Kitap Yönetimi
Kolay kitap ekleme ve tür seçimi ile kapsamlı kitap yönetimi.
<img width="2558" height="1391" alt="image" src="https://github.com/user-attachments/assets/b47b418d-1518-4022-a4ac-58b55398d77f" />


### Ödünç Takibi
Detaylı ödünç işlem takibi ve geri getirme tarihi kontrolü.

<img width="2557" height="1377" alt="image" src="https://github.com/user-attachments/assets/f9ac7c4c-be6c-4d6f-a666-c6b364af016c" />


## 🤝 Katkıda Bulunma

1. Bu projeyi fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 👨‍💻 Geliştirici

**Hüseyin Özden**

## 🙏 Teşekkürler

- Bootstrap ekibine modern UI bileşenleri için
- Microsoft'a ASP.NET Core framework'ü için
- Tüm açık kaynak topluluğuna

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
