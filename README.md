# Kütüphane Yönetim API'si / Library Management API

<details>
<summary><strong>🇹🇷 Türkçe Açıklama</strong></summary>

Bu proje, modern .NET teknolojileri kullanılarak geliştirilmiş, kitapları ve ilgili verileri yönetmek için tasarlanmış bir RESTful Web API'sidir. Proje, Project Gutenberg gibi dış kaynaklardan otomatik olarak veri çekip kendi veritabanını besleyebilen otonom bir arka plan servisi içermektedir.

## 🚀 Temel Özellikler

- **Tam CRUD Fonksiyonelliği:** Kitaplar için tam Create, Read, Update, Delete operasyonları.
- **Otomatik Veri Toplama:** Hangfire kullanılarak, Project Gutenberg'den periyodik olarak (günlük) en popüler kitapların bilgilerini çeken bir web scraping servisi.
- **Giriş Doğrulama:** FluentValidation ile gelen verilerin doğruluğunu ve tutarlılığını garanti altına alan gelişmiş model doğrulama.
- **Global Hata Yönetimi:** Middleware kullanılarak, uygulamada oluşabilecek beklenmedik hataların yakalanıp standart bir formatta kullanıcıya sunulması.

## 🛠️ Kullanılan Teknolojiler ve Mimariler

- **Backend:** C#, ASP.NET Core 8, RESTful API
- **Veri Erişimi:** Entity Framework Core (Code-First Yaklaşımı)
- **Veritabanı:** MS SQL Server
- **Arka Plan Görevleri:** Hangfire
- **Web Scraping:** HtmlAgilityPack
- **Mimari Prensipler:** N-Katmanlı Mimari, Dependency Injection

</details>

<br>

<details open>
<summary><strong>🇬🇧 English Description</strong></summary>

This is a RESTful Web API designed to manage books and related data, developed using modern .NET technologies. The project includes an autonomous background service that automatically fetches data from external sources like Project Gutenberg to populate its own database.

## 🚀 Features

- **Full CRUD Functionality:** Complete Create, Read, Update, and Delete operations for books.
- **Automated Data Scraping:** A web scraping service using Hangfire that periodically (daily) fetches data for the most popular books from Project Gutenberg.
- **Input Validation:** Advanced model validation using FluentValidation to ensure the integrity and consistency of incoming data.
- **Global Error Handling:** A custom middleware to catch unhandled exceptions and present them to the user in a standardized format.

## 🛠️ Tech Stack & Architecture

- **Backend:** C#, ASP.NET Core 8, RESTful API
- **Data Access:** Entity Framework Core (Code-First Approach)
- **Database:** MS SQL Server
- **Background Jobs:** Hangfire
- **Web Scraping:** HtmlAgilityPack
- **Architectural Principles:** N-Tier Architecture, Dependency Injection

</details>

## ⚡️ Getting Started / How to Run

1.  Clone this repository: `git clone https://github.com/kaze-9/LibraryManagement-Api.git`
2.  Update the `ConnectionStrings` section in the `appsettings.Development.json` file with your local SQL Server connection string.
3.  Open the Package Manager Console in Visual Studio and run the `Update-Database` command to create the database.
4.  Press F5 to run the project. The application will start with the Swagger UI.