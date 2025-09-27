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
