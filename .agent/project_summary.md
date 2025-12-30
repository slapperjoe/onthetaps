# Project Agent Context

## Overview
"OnTheTaps" is a full-stack .NET application hosted on Azure Static Web Apps. It manages a beer tap list system with real-time updates via Windows Notifications.

## Technology Stack

| Component | Technology | Details |
| :--- | :--- | :--- |
| **Frontend** | Blazor WebAssembly | .NET 6/7+, MudBlazor UI library. |
| **Backend** | Azure Functions | .NET Isolated Process. |
| **Database** | SQL Server | Entity Framework Core used for ORM. |
| **Storage** | Azure Blob Storage | Stores images (`.png`) and JSON definitions (`.json`) per tap. |
| **Notifications** | Azure Notification Hubs | Sends Windows Native Notifications (Toast). |
| **DevOps** | Azure Static Web Apps | CLI used for local development (`swa start`). |
| **Testing** | Playwright | E2E testing setup in `tests/` and `playwright.config.ts`. |

## Key Directories

-   `d:/onthetaps/Client`: Frontend source.
    -   `Pages/`: Blazor pages.
    -   `Shared/`: Layouts and shared components.
    -   `Program.cs`: Entry point, service registration (`MudServices`, `Authentication`).
-   `d:/onthetaps/ApiIsolated`: Backend source.
    -   `TapOps.cs`: Main logic for Tap management (Uploads, Listings, Notifications).
    -   `Program.cs`: Function host configuration, DB Context injection.
-   `d:/onthetaps/Shared`: Code shared between Client and API (Models, DTOs).

## Key API Endpoints (Azure Functions)

All endpoints are HTTP triggered.

-   `GET /api/Taplist`: Returns all taps.
-   `GET /api/Taplist/{tapNo}`: Returns details for a specific tap.
-   `POST /api/FileUpload`: Uploads an image, converts to PNG without background transparency?, hashes it, and saves detailed metadata.
-   `POST /api/DataUpload`: Uploads beer JSON data, updates SQL DB, and triggers notification.
-   `POST /api/UpdateAvailability`: Updates the `Empty` status of a tap.

## Development Notes
-   **Local Run**: Use `npm start` which wraps `swa start`.
-   **Image Processing**: The `FileUpload` function uses `SixLabors.ImageSharp` to process images (convert to PNG).
-   **Notifications**: Uses a template XML file `./datastore/BeerUpdate.xml` (path relative to function execution) to format toast notifications.
