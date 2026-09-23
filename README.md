# Budget Manager API

A budget management REST API built to practise **Clean Architecture** in .NET — layered boundaries, dependency injection per layer, encrypted persistence and unit tests.

> Portfolio / learning project. Not a production system.

## Architecture

```
BudgetManager.Presentation    ASP.NET Core Web API — controllers, Swagger, app entry point
        │
BudgetManager.Ioc             composition root — the only place layers are wired together
        │
BudgetManager.Application     DTOs, interfaces, services (use cases)
        │
BudgetManager.Domain          entities, enums, repository interfaces — zero external dependencies
        ▲
BudgetManager.Infrastructure  data access (PostgreSQL / Npgsql), encryption service, DI
```

**Decisions and why**

- **The domain knows nothing.** `Domain` has no package references to EF, Npgsql or ASP.NET. Business rules can be tested and explained without a database.
- **A dedicated `Ioc` project.** `Presentation` never references `Infrastructure` directly — dependencies are glued in one place, so swapping an implementation is a one-file change instead of a hunt.
- **Interfaces live with the domain, implementations live outside it.** `Domain/Interfaces` declares what the core needs; `Infrastructure` satisfies it. Dependency direction points inward.
- **Encryption as a service, key from the environment.** Sensitive values are encrypted before they hit the database, and the key is supplied at runtime rather than baked into the build.
- **DTOs at the boundary.** `Application/DTOs` keeps entities from leaking into the API contract.

Domain model: `User`, `UserGroup`, `UserBudget`, `Budget`, `BudgetIncome`, `BudgetCost`.

## Stack

- **.NET 8** · ASP.NET Core Web API
- **PostgreSQL** via Npgsql
- **Swagger / OpenAPI** for interactive docs
- **xUnit** for unit tests
- **Docker Compose** for the API + database

## Running locally

```bash
docker compose up --build
```

- API: `http://localhost:8080`
- Swagger UI: `http://localhost:8080/swagger` (enabled in `Development` and `Docker` environments)

Environment variables consumed by the API:

| Variable | Purpose |
|---|---|
| `ASPNETCORE_ENVIRONMENT` | `Development` / `Docker` / `Production` |
| `DB_PROVIDER` | Database provider (e.g. `NPGSQL`) |
| `DB_CONNECTION_STRING` | Database connection string |
| `BM_DEFAULT_ENCRYPTION_KEY` | Key used by the encryption service |

Or run it straight from the project without Docker:

```bash
dotnet run --project BudgetManager.Presentation
```

### ⚠️ Two things to fix in this repo

1. **`docker-compose.yml` points at the wrong Dockerfile path.** It references `BudgetManagerApi/Dockerfile`, but the file lives at `BudgetManager.Presentation/Dockerfile` — so `docker compose up --build` fails until the path is corrected.
2. **Credentials are committed in `docker-compose.yml`.** A database connection string and the encryption key are in the file. Both should be rotated and moved to a git-ignored `.env` file (`env_file:` in Compose), then purged from history.

## Project structure

```
BudgetManager.Domain/          entities, enums, repository interfaces
BudgetManager.Application/     DTOs, interfaces, services
BudgetManager.Infrastructure/  data access, encryption service, DI
BudgetManager.Ioc/             composition root
BudgetManager.Presentation/    controllers, Swagger, Program.cs, Dockerfile
BudgetManager.UnitTests/       tests
```

## Tests

```bash
dotnet test
```

## Status

Structure and dependency wiring are complete; the API surface (controllers/services) is the part still being filled in. Last commit: October 2024.

Next up: finish the budget/income/cost endpoints, add integration tests against a real PostgreSQL via Testcontainers, and fix the two issues above.

## License

MIT — see [LICENSE](LICENSE).
