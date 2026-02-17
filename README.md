# tpFINAL

This is the final version of the ASP.NET Core MVC project, featuring a Generic Repository pattern, Identity management with custom user fields, and a shopping cart system.

## Features

- **Generic Repository Pattern**: Implemented for cleaner data access.
- **ASP.NET Core Identity**: Custom user model (`ApplicationUser`) extending `IdentityUser` with a `City` property.
- **User Listing**: Admin view to list all registered users.
- **Shopping Cart**: `PanierParUser` system to manage products per user.
- **SQLite Database**: Cross-platform compatibility.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

1.  **Clone the repository** (if applicable).
2.  **Navigate to the project directory**:
    ```bash
    cd tpFINAL
    ```
3.  **Restore dependencies**:
    ```bash
    dotnet restore
    ```
4.  **Update the database** (if strictly necessary, but `tpFINAL.db` should be included if desired, though usually gitignored. Here configured to assume it might be generated):
    ```bash
    dotnet ef database update --context ApplicationDbContext
    ```
5.  **Run the application**:
    ```bash
    dotnet run
    ```
6.  **Access the app**:
    Open your browser and navigate to `http://localhost:5000` (or the port shown in the terminal).

## Structure or important files

- `Repositories/`: Contains `GenericRepository` and specific repositories.
- `Services/`: Business logic layer.
- `Controllers/`: MVC controllers (`AccountController`, `CustomerController`, etc.).
- `Models/`: Entity models (`ApplicationUser`, `Produit`, `PanierParUser`, etc.).
- `unit_tests/`: (If added) Contains test projects.

## Notes

- The project uses SQLite for development ease. The connection string is in `appsettings.json`.
