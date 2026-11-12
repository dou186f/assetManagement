# Asset Management System

A .NET MAUI asset tracking application developed during an internship for use on handheld terminals in a factory. The mobile app uses an ASP.NET Core API and SQL Server to manage current equipment and department assignments.

## Features

- **Employee Records** - View employees, registry numbers and current departments. The API supports creating employee records; the mobile app does not provide profile editing.
- **Asset Assignment** - View equipment, serial numbers, owners and assignment dates. Assign equipment, confirm reassignment to another employee, or return equipment to storage. Equipment condition and return history are not implemented.
- **Department Assignment** - Assign employees to departments, confirm transfers and remove department assignments.
- **Search & Filter** - Search employee and equipment names, equipment serial numbers and exact numeric employee registry numbers. Filter by All, Employee or Asset. Record IDs are displayed but are not searched. The API can also search department or category names when those types are explicitly requested; mobile search does not expose those types. Search requests from the app take at most 200 results.
- **Category & Department Browsing** - View categories and their equipment, or departments and their employees.
- **Data Refresh** - Search results load when a search is submitted. Category and department lists reload when their pages appear. Detail views load during initialization, and the affected detail is reloaded after assignment or removal attempts. There is no automatic real-time synchronization.
- **RESTful API & SQL Server** - ASP.NET Core endpoints with Entity Framework Core persistence. No separate web frontend is included.

## Tech Stack

| Layer | Technology |
|---|---|
| Mobile Frontend | .NET MAUI, .NET 8 targets |
| Backend | ASP.NET Core Web API, .NET 8 |
| ORM | Entity Framework Core 9.0.8 |
| Database | Microsoft SQL Server |
| Architecture | MVVM + Repository Pattern |
| MVVM Toolkit dependency | CommunityToolkit.Mvvm 8.4.0 |
| Language | C# |
| Tools | Visual Studio 2022, SSMS, GitHub |

## Screenshots

<table>
  <tr>
    <td><img src="screenshots/MainPage.jpeg" width="200"/></td>
    <td><img src="screenshots/MainPageSearch.jpeg" width="200"/></td>
    <td><img src="screenshots/MainPageSearch2.jpeg" width="200"/></td>
    <td><img src="screenshots/CategoryDetail.jpeg" width="200"/></td>
  </tr>
  <tr>
    <td><img src="screenshots/DepartmentsPage.jpeg" width="200"/></td>
    <td><img src="screenshots/DepartmentDetail.jpeg" width="200"/></td>
    <td><img src="screenshots/ItemDetail.jpeg" width="200"/></td>
    <td><img src="screenshots/ItemDetail2.jpeg" width="200"/></td>
  </tr>
</table>

## Getting Started

```bash
git clone https://github.com/dou186f/assetManagement.git
cd assetManagement
```

1. **Prerequisites:** Install a .NET 8 SDK and matching .NET MAUI workloads with Visual Studio 2022's .NET MAUI development tools. The API targets `net8.0` and requires the ASP.NET Core 8 runtime. Package versions are declared in the project files (including EF Core and its SQL Server provider 9.0.8); no `global.json` pins an SDK. Android builds require the Android SDK/JDK supported by the selected MAUI workload. The project minimum is Android API 21; Windows targets SDK 10.0.19041.0 and requires at least Windows build 17763. iOS/Mac Catalyst builds require a Mac and compatible Xcode/MAUI tooling.
2. **API configuration:** Replace the example `ConnectionStrings:DefaultConnection` in `assetManagement.API/appsettings.json`, override it in `appsettings.Development.json`, or set the environment variable `ConnectionStrings__DefaultConnection`. Supply your SQL Server instance, database and authentication. The committed server name is a placeholder.
3. **Database preparation:** No migrations, SQL scripts or seed data are included. The API does not automatically create or migrate a database. Provide a compatible schema or create and review an initial EF migration yourself using `dotnet-ef` 9.0.8, apply it to your configured database, and populate test data. `DataContext` expects `employees`, `departments`, `assets` and `categories` matching the API models. Review relationships and constraints separately, since navigation relationships are not configured in these models. Unowned equipment must use `ownerId = NULL` and no assignment date. This database setup has not been supplied or verified by the repository.
4. **Start the API:** From the repository root:

   ```bash
   dotnet restore assetManagement.API/assetManagement.API.csproj
   dotnet dev-certs https --trust
   dotnet run --project assetManagement.API/assetManagement.API.csproj --launch-profile https
   ```

   `assetManagement.API/Properties/launchSettings.json` defines `https://localhost:7145` and `http://localhost:5259` for the HTTPS profile. Swagger is available at `https://localhost:7145/swagger` in Development. The API redirects HTTP to HTTPS. Opening Swagger alone does not verify database readiness.
5. **Configure and build the app:** Open `assetManagementProject.sln`, select a supported mobile target and restore/build using compatible .NET 8 MAUI tooling. `baseUri` in `assetManagement.MOBILE/MauiProgram.cs` is `https://localhost:7145` in both Debug and Release, matching the API HTTPS profile for a client on the same computer. Set it to your actual HTTPS API endpoint for deployment. For Android:

   ```bash
   dotnet build assetManagement.MOBILE/assetManagement.MOBILE.csproj -f net8.0-android
   ```

   **Android emulator:** Its `localhost` is the emulator. The standard Android emulator can reach the host through `10.0.2.2`; using `https://10.0.2.2:7145` requires a reachable API binding and a certificate trusted by the emulator/app whose subject alternative names cover that address. The localhost development certificate does not cover `10.0.2.2`. Alternatively, configure `adb reverse tcp:7145 tcp:7145` to forward the emulator's localhost port to the host, and configure app/device trust for the localhost development certificate. Trust on the computer alone is insufficient.

   **Physical device/handheld terminal:** Use a reachable LAN DNS name/address or a configured HTTPS tunnel and update `baseUri`. For LAN access, bind Kestrel to the required network interface using a local launch profile or `ASPNETCORE_URLS` with `--no-launch-profile`, configure its HTTPS certificate and allow the port through the firewall. The device must have network access, and the certificate must match the API hostname/address and chain to a CA trusted by the device and app. The device's localhost does not refer to the development computer. An iOS simulator on a Mac likewise needs a reachable HTTPS address when the API runs on another computer.

   Keep HTTPS certificate validation enabled. No bypass is configured in the app. Local launch settings do not publish an API or configure remote-device access. The example SQL connection string's `TrustServerCertificate=True` is a separate database connection setting; configure SQL certificate trust appropriately for deployment.

## Author

**Doğu Erbaş**  
doguerbass@gmail.com  
Developed as an internship project.
