CleanArchitecture.DemoApp (LeaveManagement)

A sample implementation of Clean Architecture for a Leave Management system (solution: LeaveManagement.sln). This repository demonstrates a layered project structure following Clean Architecture principles: API, Application, Domain, Infrastructure, and Tests.

Purpose: to show architecture patterns, separation of concerns, and a scalable .NET project layout suitable for learning, interviews, and small production demos.

Table of Contents

Features

Architecture

Prerequisites

Run locally

Tests

Docker (example)

Suggested CI (GitHub Actions)

Developer notes

Contributing

License

Contact

Features

Layered project structure based on Clean Architecture

Clear separation of Domain (entities & business rules), Application (use-cases/commands/queries), and Infrastructure (EF Core, persistence, external integrations)

A minimal REST API in API project

Unit and/or integration test project under Tests

Architecture
API  <-- depends on -- Application  <-- depends on -- Domain
                     \
                      \-- Infrastructure (implements interfaces)


Tests (project) covers Application + API

Layer responsibilities

Domain: Entities, Value Objects, Domain rules and enums.

Application: DTOs, Interfaces, Use Cases (Commands/Queries/Handlers), application-level validations.

Infrastructure: Data access (EF Core), repository implementations, external service adapters, migrations and seeds.

API: HTTP controllers, request/response mapping, dependency injection and host configuration.

Prerequisites

.NET SDK 6.0 or later (recommended: .NET 7 or 8)

Optional: Docker (if you want to run the API in a container)

Optional: Local database (SQL Server, SQLite, or other) if the project uses EF Core

Check the project csproj files for a pinned SDK version and use the same runtime (dotnet --version).
