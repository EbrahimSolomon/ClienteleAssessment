# 📚 Library Management System

A simple, clean, and modular **Blazor WebAssembly (WASM)** + **ASP.NET Core Web API** application with **SQLite** database integration. This assessment showcases a basic **library system** allowing users to add, delete, and search books.

---

## 🚀 Technologies Used

- ASP.NET Core 8.0 Web API
- Blazor WebAssembly (WASM)
- Entity Framework Core with SQLite
- Clean Architecture Principles (SOLID)
- Swagger for API Testing

## ⚙️ Prerequisites

- Visual Studio 2022
- .NET 8.0 SDK
- SQLite (automatically created)
- Browser (Chrome, Edge, etc.)

---

## 🚀 Running the Application

### 🔧 Step 1: Set Multiple Startup Projects

- Right-click the solution > **Set Startup Projects**
- Select **Multiple startup projects**
  - `LibraryManagement.Server` – **Start**
  - `LibraryManagement.Website` – **Start**

### 🔧 Step 2: Run the App

Press `F5` in Visual Studio.

- API will run at: `https://localhost:7218`
- Client will run at: `https://localhost:7281`

---

## 🔄 API Endpoints

**Base URL:** `https://localhost:7218/api/books`

| Verb   | Endpoint            | Description             |
|--------|---------------------|-------------------------|
| GET    | `/api/books`        | Get all books           |
| GET    | `/api/books/{id}`   | Get a specific book     |
| POST   | `/api/books`        | Add a new book          |
| DELETE | `/api/books/{id}`   | Delete a book           |
| GET    | `/api/books/search/{keyword}` | Search books |

---

## 📦 Features

- Add, view, delete, and search books
- SOLID architecture with service & repository layers
- Shared DTOs between client and server
- SQLite for easy setup
- Swagger UI at `/swagger`

---

## 🧪 Testing

> [Optional] Unit tests can be added for service and repository layers using xUnit.
(If I have more time, I will implement this. It shouldn't take longer than 30min...)

---

## 📌 Assumptions

- No user authentication
- No pagination or advanced filtering
- SQLite is used for simplicity and runs locally
- CORS is configured to allow requests from `https://localhost:7281`

---

## 🔐 CORS Configuration

API must allow requests from the Blazor WASM app:

**`Program.cs` in `LibraryManagement.Server`**
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWasmClient",
        policy => policy.WithOrigins("https://localhost:7281")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

app.UseCors("AllowWasmClient");


📸 UI Preview

-- I need to use MudBlazor and modify the UI more. If I have some time after today I will make some UI mods!

🙌 Author
Developed by Ebrahim Solomon as part of a coding assessment.