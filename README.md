# On The Taps

[https://onthetaps.com](https://onthetaps.com)

"On The Taps" is a web application designed for managing and updating beer tap lists, specifically targeting Windows Mobile Taps. It allows for the management of beer details, images, and availability.

## Architecture

The solution uses a **Azure Static Web Apps** architecture:

-   **Client**: A **Blazor WebAssembly** application built with .NET and **MudBlazor** for the UI.
-   **API**: An **Azure Functions (Isolated Process)** project handling backend logic.
-   **Database**: Uses **Entity Framework Core** with SQL Server.
-   **Storage**: Azure Blob Storage for storing beer images and JSON data.
-   **Notifications**: Azure Notification Hubs for sending updates to Windows devices.

## Project Structure

-   `Client/`: Blazor WebAssembly frontend project.
-   `ApiIsolated/`: Azure Functions backend project.
-   `Shared/`: Shared models and DTOs between Client and API.
-   `package.json`: NPM configuration for running the Static Web Apps CLI.
-   `playwright.config.ts`: Configuration for Playwright end-to-end tests.

## Prerequisites

-   .NET 7.0 SDK (or later)
-   Node.js (for SWA CLI)
-   Azure Static Web Apps CLI (`npm install -g @azure/static-web-apps-cli`)
-   Azure Storage Emulator (or Azurite) for local development
-   SQL Server (or LocalDB)

## Getting Started

1.  **Clone the repository**.
2.  **Install dependencies**:
    ```bash
    npm install
    ```
3.  **Configure Local Settings**:
    -   Ensure `ApiIsolated/local.settings.json` is configured with necessary connection strings:
        -   `DBConnection`: Connection string for SQL Server.
        -   `BigBeerStorageAccount`: Connection string for Azure Blob Storage.
        -   `AzureWebJobsStorage`: Connection string for Azure Functions storage.
        -   Notification Hub configurations (if testing notifications).

4.  **Run the application (Client + API)**:
    The project includes a start script using the Azure Static Web Apps CLI.
    ```bash
    npm start
    ```
    This command runs: `swa start http://localhost:5000 --run 'dotnet run --project Client/Client.csproj' --api-location Api`

    The application should be accessible at `http://localhost:4280` (SWA emulator port).

## Key Features

-   **Tap Management**: Update beer details for specific tap numbers.
-   **Image Upload**: Upload images for beers on tap.
-   **Availability**: Mark taps as empty or available.
-   **Push Notifications**: Triggers Windows native notifications when taps are updated.
