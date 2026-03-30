# Sayara – Car Rental & Selling Platform

This is the final version of **Sayara**, a web application for renting and selling cars. It is built with **ASP.NET Core MVC** and features a **Generic Repository pattern**, **ASP.NET Core Identity** with custom user fields, and a **user-specific shopping/rental cart system**.  

## Features

- **Generic Repository Pattern** – Clean and maintainable data access.
- **ASP.NET Core Identity** – Custom user model (`ApplicationUser`) with extra fields such as `City`.
- **User Management** – Admin can view all registered users.
- **Car Rental & Selling Cart** – `PanierParUser` system to manage car rentals/purchases per user.
- **Car Listings** – CRUD operations for car listings.
- **SQLite Database** – Lightweight and cross-platform.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- (Optional) [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code

## Getting Started

1. **Clone the repository** (if applicable):
    ```bash
    git clone https://github.com/yourusername/Sayara.git
    cd Sayara
    ```
2. **Restore dependencies**:
    ```bash
    dotnet restore
    ```
3. **Update the database**:
    ```bash
    dotnet ef database update --context ApplicationDbContext
    ```
    > The SQLite database (`Sayara.db`) can be included or generated automatically.
4. **Run the application**:
    ```bash
    dotnet run
    ```
5. **Access the app**:  
    Open your browser and navigate to `http://localhost:5000` (or the port shown in the terminal).

## Project Structure

- `Repositories/` – Contains `GenericRepository` and specialized repositories.
- `Services/` – Contains business logic and service layer code.
- `Controllers/` – MVC controllers (`AccountController`, `CarController`, `CartController`, etc.).
- `Models/` – Entity models (`ApplicationUser`, `Car`, `PanierParUser`, etc.).
- `Views/` – Razor views for frontend pages.
- `wwwroot/` – Static assets (CSS, JS, images).
- `unit_tests/` – Contains unit tests (if added).

## Notes

- Uses **SQLite** for development; connection string is in `appsettings.json`.
- Designed for both **car rental** and **car selling** operations.
- Supports **user-specific carts**, so users can manage rentals or purchases separately.
