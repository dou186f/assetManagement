# Asset Management System

A mobile and web-based asset tracking solution developed during an internship. Enables organizations to assign equipment and tools to employees, and monitor their status in real time.

## Features

- **Employee Management** — Create, update, and list employee records
- **Asset Assignment** — Assign assets to employees and track returns and conditions
- **Search & Filter** — Query assets or employees by name or ID
- **Mobile App (MAUI)** — Field-friendly interface for on-site staff
- **RESTful API** — ASP.NET Core backend for all data operations
- **SQL Server Integration** — Persistent storage with a relational database

## Tech Stack

| Layer | Technology |
|---|---|
| Mobile Frontend | .NET MAUI |
| Backend | ASP.NET Core Web API |
| Database | Microsoft SQL Server |
| Architecture | MVVM + Repository Pattern |
| Language | C# |
| Tools | Visual Studio 2022, SSMS 21, GitHub |

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
git clone https://github.com/dou186f/assetManagementProject.git
```

1. Open the solution in Visual Studio 2022.
2. Configure the API base URL in the mobile project to point to your local server.
3. Set up a local SQL Server instance and populate it with the required tables and seed data.
4. Build and deploy the mobile app to an emulator or physical device.

> **Note:** The API is not connected to a live server. Local setup with a dummy database is required for testing.

## Roadmap

- [ ] Authentication and user login
- [ ] PDF / Excel report generation
- [ ] Push notifications for asset return deadlines

## Author

**Doğu Erbaş**  
doguerbass@gmail.com  
Developed as an internship project.
