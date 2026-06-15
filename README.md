<div align="center">

# ✅ Task Manager App

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)](https://www.sqlite.org)
[![Bootstrap](https://img.shields.io/badge/Bootstrap_5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com)
[![Azure](https://img.shields.io/badge/Azure_App_Service-0078D4?style=for-the-badge&logo=microsoftazure&logoColor=white)](https://azure.microsoft.com)

**A full-stack task management web application built with ASP.NET Core 8 MVC, Entity Framework Core, and ASP.NET Identity — deployed live on Microsoft Azure.**

[🌐 Live Demo](http://task-manager-bhumika.azurewebsites.net) · [🎬 Demo Video](https://drive.google.com/file/d/1FPU0t2LAPr9QsXTqGk-L--XXq6FHe20X/view?usp=drive_link) · [🐛 Report Bug](https://github.com/BhumikaBC07/task-manager-aspnet/issues)

</div>

---

## 🎬 Demo

> **Watch the full walkthrough:**

[![Task Manager Demo](https://img.shields.io/badge/▶_Watch_Demo-Google_Drive-4285F4?style=for-the-badge&logo=googledrive&logoColor=white)](https://drive.google.com/file/d/1FPU0t2LAPr9QsXTqGk-L--XXq6FHe20X/view?usp=drive_link)

> ⚠️ *Hosted on Azure Free tier — first request may take ~10s to cold-start.*

---

## 📌 What Is This?

Task Manager is a **production-deployed full-stack web application** built with the Microsoft ASP.NET Core stack. It covers the complete user journey: register an account, log in securely, create and manage tasks, track completion status, and log out. All task routes are protected — unauthenticated users are automatically redirected to login.

Built to demonstrate hands-on proficiency in ASP.NET Core MVC, Entity Framework Core, ASP.NET Identity, and Azure deployment.

---

## ✨ Features

### 👤 Authentication
- User registration and login via **ASP.NET Identity**
- Cookie-based session management with automatic redirect to `/Account/Login` for protected routes
- Password hashing with configurable policy enforcement (min 6 chars, no special character requirement)
- Login/Logout with navbar state reflecting authentication status

### 📋 Task Management
- **Create** tasks with title, description, and completion status
- **Read** all tasks displayed as responsive Bootstrap 5 cards with Done/Pending badges
- **Update** task details and toggle completion status via Edit form
- **Delete** tasks with confirmation page
- Description truncation at 100 characters to prevent UI overflow

### ⚙️ Technical
- MVC architecture with dependency injection for DbContext and Identity services
- Entity Framework Core migrations for schema management
- Environment-specific SQLite paths (local vs Azure Linux runtime)
- Auto-database initialization via `EnsureCreated()` on startup
- Deployed on **Azure App Service** (Linux, F1 free tier) using Azure CLI

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET Core 8 MVC |
| Language | C# |
| ORM | Entity Framework Core 8 |
| Auth | ASP.NET Identity |
| Database | SQLite |
| Frontend | Razor Views + Bootstrap 5 |
| Deployment | Microsoft Azure App Service (Linux) |
| Version Control | Git + GitHub |

---

## 🏗️ Architecture
┌─────────────────────────────────────────┐

│           CLIENT (Browser)              │

│     Razor Views + Bootstrap 5           │

└────────────────┬────────────────────────┘

│ HTTP

▼

┌─────────────────────────────────────────┐

│     ASP.NET Core 8 MVC (Azure)          │

│                                         │

│  ┌──────────┐  ┌──────────┐            │

│  │ Account  │  │  Tasks   │            │

│  │Controller│  │Controller│            │

│  └──────────┘  └──────────┘            │

│         │             │                │

│    ASP.NET Identity   EF Core          │

└────────────────┬────────────────────────┘

│

▼

┌─────────────────────────────────────────┐

│         SQLite Database                 │

│    /home/taskmanager.db (Azure)         │

│    taskmanager.db (local)               │

└─────────────────────────────────────────┘

---

## 📁 Project Structure
TaskManagerApp/

├── Controllers/

│   ├── AccountController.cs    # Register, Login, Logout

│   ├── TasksController.cs      # CRUD operations for tasks

│   └── HomeController.cs       # Landing page

├── Models/

│   ├── TaskItem.cs             # Task entity (EF Core model)

│   ├── LoginViewModel.cs       # Login form binding

│   └── RegisterViewModel.cs    # Register form binding

├── Views/

│   ├── Account/

│   │   ├── Login.cshtml

│   │   └── Register.cshtml

│   ├── Tasks/

│   │   ├── Index.cshtml        # Task list with cards

│   │   ├── Create.cshtml

│   │   ├── Edit.cshtml

│   │   └── Delete.cshtml

│   ├── Home/

│   │   └── Index.cshtml        # Landing page

│   └── Shared/

│       └── _Layout.cshtml      # Navbar + footer

├── Data/

│   └── AppDbContext.cs         # EF Core DbContext + Identity

├── Migrations/                 # EF Core migration files

├── Program.cs                  # App configuration + middleware

└── appsettings.json

---

## ⚙️ Local Setup

### Prerequisites
- .NET 8 SDK — [Download](https://dotnet.microsoft.com/en-us/download/dotnet/8)
- Git

### Run Locally

```bash
# Clone
git clone https://github.com/BhumikaBC07/task-manager-aspnet.git
cd task-manager-aspnet/TaskManagerApp

# Apply migrations and create local database
dotnet ef database update

# Run
dotnet run
```

Open `http://localhost:5266` — register an account and start creating tasks.

---

## 🐛 Real Deployment Challenges Solved

| Problem | Root Cause | Fix |
|---------|-----------|-----|
| Azure build failed with NETSDK1045 | SQLite package auto-upgraded project to .NET 10; Azure only had .NET 8 SDK | Manually downgraded all EF Core packages to `8.0.8` in `.csproj` |
| `MapStaticAssets` compile error after downgrade | Method introduced in .NET 9, not available in .NET 8 | Replaced with `UseStaticFiles()` |
| SQLite `unable to open database file` on Azure | Hardcoded `/home/taskmanager.db` path doesn't exist locally on Windows | Added environment check — uses `/home/taskmanager.db` on Production, `taskmanager.db` locally |
| Database not created on Azure startup | `EnsureCreated()` was placed after `app.Run()` which is blocking | Moved before `app.Run()` |
| Git `dubious ownership` error | Project folder owned by Administrators group, not current user | Added safe directory via `git config --global --add safe.directory` |

---

## 🚀 Deployment

Deployed on **Microsoft Azure App Service** using Azure CLI:

```bash
az webapp up \
  --name task-manager-bhumika \
  --runtime "DOTNETCORE:8.0" \
  --sku F1 \
  --location southindia \
  --os-type Linux
```

- Runtime: .NET 8 on Linux
- Tier: Free (F1)
- Database: SQLite at `/home/taskmanager.db`
- Auto-initialized on first startup via `EnsureCreated()`

---

## 📄 License

MIT License — see [LICENSE](https://github.com/BhumikaBC07/task-manager-aspnet/blob/main/LICENSE) for details.

---

<div align="center">

Built by [Bhumika Chuchakoti](https://github.com/BhumikaBC07)

*ASP.NET Core · C# · Entity Framework Core · ASP.NET Identity · SQLite · Azure*

</div>
