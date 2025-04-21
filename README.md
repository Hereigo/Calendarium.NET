# Clean Architecture

A modular ASP.NET MVC application following Clean Architecture principles.

## 📦 Solution Structure

```sql
Calendarium.sln
|
├── src
│   ├── Calendarium.Web               --> ASP.NET MVC UI project
│   ├── Calendarium.Application       --> Business logic, use cases, DTOs
│   ├── Calendarium.Domain            --> Core domain entities and interfaces
│   ├── Calendarium.Infrastructure    --> Infrastructure implementations (EF, external APIs)
│
├── tests
│   ├── Calendarium.UnitTests         --> Unit tests
│   ├── Calendarium.IntegrationTests  --> Integration tests
│
├── build                      --> Build scripts, CI/CD configs
├── docs                       --> Documentation
└── README.md
```

### Presentation Layer - Handles all HTTP interaction (MVC Controllers, Views, Filters, ViewModels).

```sql
Calendarium.Web
│
├── Controllers
├── Views
│   ├── Home
│   └── Shared
├── ViewModels
├── Filters
├── Scripts
├── Content (CSS/images)
└── Startup.cs / Global.asax.cs

```

### Application Layer - Contains business logic and application use cases.

```sql
Calendarium.Application
│
├── Interfaces               --> Interfaces for services, repositories
├── Services                 --> Business services (application layer logic)
├── UseCases                 --> Specific use case handlers
├── DTOs                     --> Data Transfer Objects
└── Exceptions
```

### Domain Layer - Core business logic, models, and rules. Should be free of any dependencies.

```sql
Calendarium.Domain
│
├── Entities
├── ValueObjects
├── Interfaces               --> Core contracts (e.g., IRepository)
├── Enums
└── DomainEvents
```

### Infrastructure Layer - Contains concrete implementations: database access, external services, etc.

```sql
Calendarium.Infrastructure
│
├── Data
│   ├── Migrations
│   ├── Context              --> EF DbContext
│   └── Repositories
├── Services                 --> External service implementations (e.g., email, file storage)
└── Configuration
```

### Test Projects - Each test project should be in its own folder with a similar structure to the layers they're testing.

```sql
Calendarium.UnitTests
├── Application
├── Domain

Calendarium.IntegrationTests
├── Infrastructure
├── Web
```

### Extras (Optional)

```sql
Calendarium.Shared: Shared utilities like logging, constants, helpers

Calendarium.Contracts: If you use message-based architecture (e.g., CQRS, MediatR)
```

### Step-by-step CLI generation:

```sh
mkdir Calendarium
cd Calendarium
dotnet new sln -n Calendarium
dotnet new mvc -n Calendarium.Web
dotnet new classlib -n Calendarium.Application
dotnet new classlib -n Calendarium.Domain
dotnet new classlib -n Calendarium.Infrastructure

dotnet new xunit -n Calendarium.UnitTests
dotnet new xunit -n Calendarium.IntegrationTests

dotnet sln add ./Calendarium.Web/Calendarium.Web.csproj
dotnet sln add ./Calendarium.Application/Calendarium.Application.csproj
dotnet sln add ./Calendarium.Domain/Calendarium.Domain.csproj
dotnet sln add ./Calendarium.Infrastructure/Calendarium.Infrastructure.csproj
dotnet sln add ./Calendarium.UnitTests/Calendarium.UnitTests.csproj
dotnet sln add ./Calendarium.IntegrationTests/Calendarium.IntegrationTests.csproj

# Dependencies:

dotnet add ./Calendarium.Web/Calendarium.Web.csproj reference ./Calendarium.Application/Calendarium.Application.csproj
dotnet add ./Calendarium.Web/Calendarium.Web.csproj reference ./Calendarium.Infrastructure/Calendarium.Infrastructure.csproj

dotnet add ./Calendarium.Application/Calendarium.Application.csproj reference ./Calendarium.Domain/Calendarium.Domain.csproj

dotnet add ./Calendarium.Infrastructure/Calendarium.Infrastructure.csproj reference ./Calendarium.Application/Calendarium.Application.csproj
dotnet add ./Calendarium.Infrastructure/Calendarium.Infrastructure.csproj reference ./Calendarium.Domain/Calendarium.Domain.csproj

dotnet add ./Calendarium.Infrastructure/Calendarium.Infrastructure.csproj package Microsoft.EntityFrameworkCore

# Optionally, use MediatR or AutoMapper if you're building a full clean architecture setup.
```
