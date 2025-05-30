# BuberDinner

A .NET-based restaurant management system built using Clean Architecture principles.

## 🏗️ Architecture

This project follows Clean Architecture principles, organizing the codebase into distinct layers:

### Core Layers

- **Domain Layer** (`BuberDiner.Domain`)

  - Contains enterprise business rules
  - Entities and business objects
  - Domain events and exceptions
  - Value objects and enums

- **Application Layer** (`BuberDinner.Application`)
  - Contains business use cases
  - Interfaces for repositories and services
  - DTOs and mapping profiles
  - Application-specific business rules

### Infrastructure Layers

- **Infrastructure Layer** (`BuberDiner.Infrastructure`)

  - Implements interfaces defined in the Application layer
  - Database context and configurations
  - External service implementations
  - Cross-cutting concerns

- **API Layer** (`BuberDiner.Api`)

  - REST API endpoints
  - Controllers
  - API configurations
  - Middleware

- **Contracts Layer** (`BuberDiner.Contracts`)
  - API request/response models
  - Shared DTOs
  - API documentation

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- Your preferred IDE (Visual Studio, VS Code, etc.)

### Running the Application

1. Clone the repository
2. Navigate to the solution directory
3. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run --project BuberDiner.Api
```

The API will be available at `http://localhost:5036`

## 🏗️ Project Structure

```
BuberDinner/
├── BuberDiner.Api/           # API Layer
├── BuberDiner.Contracts/     # API Contracts
├── BuberDiner.Domain/        # Domain Layer
├── BuberDiner.Infrastructure/# Infrastructure Layer
└── BuberDinner.Application/  # Application Layer
```

## 🔄 Clean Architecture Principles

This project adheres to Clean Architecture principles:

1. **Independence of Frameworks**: The core business logic is independent of any external frameworks
2. **Testability**: Business rules can be tested without UI, database, or external elements
3. **Independence of UI**: UI can change without changing the rest of the system
4. **Independence of Database**: Business rules are not bound to the database
5. **Independence of External Agency**: Business rules don't know about the outside world

## 📝 API Documentation

The API documentation is available at `/swagger` when running the application.

## 🛠️ Technologies Used

- .NET 8.0
- Clean Architecture
- REST API
- Entity Framework Core
- MediatR (for CQRS pattern)
- FluentValidation
- AutoMapper

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request
