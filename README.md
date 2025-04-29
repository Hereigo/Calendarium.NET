# Clean Architecture

A modular ASP.NET MVC application following Clean Architecture principles.

## 📦 Solution Structure

```sql
MyApp.sln
|
├── src
│   ├── MyApp.Application       --> Business logic, use cases, DTOs
│   ├── MyApp.Domain            --> Core domain entities and interfaces
│   ├── MyApp.Infrastructure    --> Infrastructure implementations (EF, external APIs)
│   ├── MyApp.Web               --> ASP.NET MVC UI project
│
├── tests
│   ├── MyApp.UnitTests         --> Unit tests
│   ├── MyApp.IntegrationTests  --> Integration tests
│
├── build                       --> Build scripts, CI/CD configs
├── docs                        --> Documentation
└── README.md
```

### Presentation Layer - Handles all HTTP interaction (MVC Controllers, Views, Filters, ViewModels).

```sql
MyApp.Web
│
├── Content (CSS/images)
├── Controllers
├── Filters
├── ViewModels
├── Views
│   ├── Home
│   └── Shared
├── Scripts
└── Startup.cs / Global.asax.cs
```

### Application Layer - Contains business logic and application use cases.

```sql
MyApp.Application
│
├── DTOs                     --> Data Transfer Objects
├── Exceptions
├── Interfaces               --> Interfaces for services, repositories
├── Services                 --> Business services (application layer logic)
└── UseCases                 --> Specific use case handlers
```

### Domain Layer - Core business logic, models, and rules. Should be free of any dependencies.

```sql
MyApp.Domain
│
├── DomainEvents
├── Entities
├── Enums
├── Interfaces               --> Core contracts (e.g., IRepository)
└── ValueObjects
```

### Infrastructure Layer - Contains concrete implementations: database access, external services, etc.

```sql
MyApp.Infrastructure
│
├── Configuration
├── Data
│   ├── Context              --> EF DbContext
│   ├── Migrations
│   └── Repositories
└── Services                 --> External services implementations (e.g., email, file storage)
```

### Test Projects - Each test project should be in its own folder with a similar structure to the layers they're testing.

```sql
MyApp.UnitTests
├── Application
├── Domain

MyApp.IntegrationTests
├── Infrastructure
├── Web
```

### Extras (Optional)

```sql
MyApp.Shared (logging, constants, helpers, etc.)

MyApp.Contracts (for message-based architecture e.g., CQRS, MediatR)
```

### Step-by-step CLI generation:

```sh
mkdir MyApp
cd MyApp
dotnet new sln -n MyApp
dotnet new mvc -n MyApp.Web
dotnet new classlib -n MyApp.Application
dotnet new classlib -n MyApp.Domain
dotnet new classlib -n MyApp.Infrastructure

dotnet new xunit -n MyApp.UnitTests
dotnet new xunit -n MyApp.IntegrationTests

dotnet sln add ./MyApp.Web/MyApp.Web.csproj
dotnet sln add ./MyApp.Application/MyApp.Application.csproj
dotnet sln add ./MyApp.Domain/MyApp.Domain.csproj
dotnet sln add ./MyApp.Infrastructure/MyApp.Infrastructure.csproj
dotnet sln add ./MyApp.UnitTests/MyApp.UnitTests.csproj
dotnet sln add ./MyApp.IntegrationTests/MyApp.IntegrationTests.csproj

# Dependencies:

dotnet add ./MyApp.Web/MyApp.Web.csproj reference ./MyApp.Application/MyApp.Application.csproj
dotnet add ./MyApp.Web/MyApp.Web.csproj reference ./MyApp.Infrastructure/MyApp.Infrastructure.csproj

dotnet add ./MyApp.Application/MyApp.Application.csproj reference ./MyApp.Domain/MyApp.Domain.csproj

dotnet add ./MyApp.Infrastructure/MyApp.Infrastructure.csproj reference ./MyApp.Application/MyApp.Application.csproj
dotnet add ./MyApp.Infrastructure/MyApp.Infrastructure.csproj reference ./MyApp.Domain/MyApp.Domain.csproj

dotnet add ./MyApp.Infrastructure/MyApp.Infrastructure.csproj package Microsoft.EntityFrameworkCore

# Optionally, use MediatR or AutoMapper if you're building a full clean architecture setup.
```
