# CustomerCore API

A clean and modular .NET 7 Web API for managing customers, built using:
- Clean Architecture principles
- Entity Framework Core
- MediatR (CQRS)
- FluentValidation
- SQL Server (LocalDB by default)

---

## 📦 Project Structure


---

## 🚀 Getting Started

### ✅ Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- SQL Server OR LocalDB (default: `MSSQLLocalDB`)
- Optional: [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)

---

## ⚙️ Configuration

Update your `appsettings.json` in `CustomerCoreAPI`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CustomerDb;Trusted_Connection=True;"
}


dotnet build
dotnet run --project CustomeCorerWebAPI


cd CustomerCoreInfrastructure
dotnet ef migrations add InitialCreate --startup-project ../CustomeCorerWebAPI

Apply Migration
dotnet ef database update --startup-project ../CustomeCorerWebAPI

API Endpoints


Once the app is running, open:

bash
Copy
Edit
https://localhost:7204/swagger


GET     /api/customers
GET     /api/customers/{id}
POST    /api/customers
PUT     /api/customers/{id}
DELETE  /api/customers/{id}



Sample Request
POST /api/customers
Content-Type: application/json

{
  "customerID": 0,
  "name": "Jane Doe",
  "email": "jane@example.com",
  "phoneNumber": "0123456789"
}

📦 Technologies
ASP.NET Core 7.0

Entity Framework Core

SQL Server (or LocalDB)

MediatR

FluentValidation

Swagger / Swashbuckle

✅ Status
✅ CRUD fully implemented
✅ CQRS with MediatR
✅ Unit of Work + Repository pattern
✅ Clean Architecture
✅ SQL DB migrations
✅ Validated inputs with FluentValidation
✅ Swagger UI

"Licensed"  ;-)
EBRAHIM SOLOMON!