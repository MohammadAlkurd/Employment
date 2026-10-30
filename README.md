# Employment API

A RESTful API built with **ASP.NET Core 8** and **Entity Framework Core** that manages employees and departments with a **one-to-many** relationship (one department has many employees). Built as a bootcamp homework assignment.

## Stack

- ASP.NET Core 8 (Web API)
- Entity Framework Core 8 + SQL Server
- Swagger / OpenAPI (Swashbuckle)

## Model

- **Department** 1──n **Employee**

## Endpoints

Base route: `api/<controller>`.

### Employees — `api/Employee`

| Method | Route | Body | Description |
|--------|-------|------|-------------|
| GET    | `/api/Employee` | — | List all employees |
| GET    | `/api/Employee/{id}` | — | Get one employee |
| POST   | `/api/Employee` | `{"name": "...", "departmentId": "..."}` | Create an employee |
| PUT    | `/api/Employee/{id}` | `{"name": "...", "departmentId": "..."}` | Update an employee |
| DELETE | `/api/Employee/{id}` | — | Delete an employee |

### Departments — `api/Department`

| Method | Route | Body | Description |
|--------|-------|------|-------------|
| GET    | `/api/Department` | — | List all departments |
| GET    | `/api/Department/{id}` | — | Get one department |
| POST   | `/api/Department` | `"name"` (raw string) | Create a department |
| PUT    | `/api/Department/{id}` | `"name"` (raw string) | Update a department |
| DELETE | `/api/Department/{id}` | — | Delete a department |

## Database setup

The connection string is a placeholder (`"SECRET STRING"`) in `Employment/Program.cs`. Point it at your SQL Server instance — preferably via user secrets or an environment variable rather than hardcoding:

```bash
dotnet user-secrets init --project Employment
```

Then run the included EF Core migrations:

```bash
dotnet ef database update --project Employment
```

## Live demo

Interactive Swagger UI (use **http**, not https):

<http://employment.runasp.net/swagger/index.html>

## Running locally

```bash
dotnet restore
dotnet run --project Employment
```

Swagger UI is enabled in all environments at `/swagger`.

## License

MIT — see [LICENSE](LICENSE).
