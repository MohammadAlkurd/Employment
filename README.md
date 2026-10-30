# Employment API

A RESTful API built with **ASP.NET Core 8** and **Entity Framework Core** that manages employees and departments with a **one-to-many** relationship (one department has many employees).

## Stack

- ASP.NET Core 8 (Web API)
- Entity Framework Core 8 + SQL Server
- Swagger / OpenAPI (Swashbuckle)

## Model

- **Department** 1──n **Employee**

## Endpoints

- `EmployeeController` — CRUD for employees
- `DepartmentController` — CRUD for departments

## Live demo

Interactive Swagger UI (use **http**, not https):

<http://employment.runasp.net/swagger/index.html>

## Running locally

```bash
dotnet restore
dotnet ef database update   # apply the included migrations
dotnet run --project Employment
```
