# Product.Server API

A clean and modular ASP.NET Core 6.0 Web API for managing products using EF Core, AutoMapper, and xUnit.

---

## 🚀 Tech Stack

- ASP.NET Core 6.0
- Entity Framework Core (Code First)
- SQL Server LocalDB
- AutoMapper
- xUnit + Moq for Unit Testing

---

## 🧱 Architecture

- **Controllers**: Handle HTTP requests
- **DTOs**: Data Transfer Objects
- **Services**: Business logic layer
- **Repositories**: Data access layer
- **Data**: EF Core `DbContext`
- **Models**: Domain entities

---

## 🛠️ Getting Started

### 🔧 Setup & Run

```bash
dotnet restore
dotnet ef database update
dotnet run --project Product.Server
