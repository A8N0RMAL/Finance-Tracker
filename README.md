## 💰 Finance Tracker - ASP.NET Core Web Application

A full-featured personal finance management web application built with ASP.NET Core MVC. This app helps users track their expenses with intuitive CRUD operations and visualize spending patterns through interactive charts.

### 🚀 Features

- **Expense Management**: Full CRUD operations (Create, Read, Update, Delete) for tracking expenses
- **Data Validation**: Comprehensive server-side and client-side validation with custom error messages
- **Interactive Charts**: Visualize spending by category using Chart.js integration
- **Category Analytics**: Group and analyze expenses by category with real-time data aggregation
- **Responsive Design**: Clean, modern UI built with Bootstrap
- **Secure Architecture**: Repository pattern with service layer abstraction

### 🛠️ Tech Stack

**Backend**: ASP.NET Core MVC, Entity Framework Core, SQL Server  
**Frontend**: HTML5, CSS3, Bootstrap, JavaScript, Chart.js  
**Architecture**: Repository Pattern, Dependency Injection, Service Layer  
**Tools**: Visual Studio, Git, SQL Server Management Studio

### 📋 Core Functionality

- Add new expenses with description, amount, date, and category
- Edit existing expenses with real-time validation
- Delete expenses with confirmation dialog
- View all expenses in organized table layout
- Analyze spending patterns with category-wise pie charts
- RESTful API endpoints for chart data

### 🏗️ Project Structure

```
FinanceApp/
├── Controllers/          # MVC Controllers
├── Models/              # Domain Models & Data Annotations
├── Data/                # DbContext & Database Configuration
├── Services/            # Business Logic Layer
└── Views/               # Razor Views
```

This project demonstrates clean architecture, separation of concerns, and modern ASP.NET Core development practices—perfect for managing personal finances or as a learning example for full-stack .NET development.

---
