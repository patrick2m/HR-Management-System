HR Management System API .NET 10 | Docker | PostgreSQL | Clean Architecture

Backend API for employee management built with .NET 10, Clean Architecture, Docker and PostgreSQL.

This project demonstrates how a production-style backend service can be structured using modern backend development practices.

Tech Stack
.NET 10
ASP.NET Core Web API
Entity Framework Core
PostgreSQL
Docker & Docker Compose
Clean Architecture

Features
Employee CRUD API
Automatic database migrations
Dockerized environment
Health check endpoint
Swagger documentation

Running the project

Clone the Repository

  git clone https://github.com/patrick2m/hr-management-system.git
  cd hr-managemente-system
  cd backend

Start the application

  docker compose up --build

The API will be availabe at

  http://localhost:8080/swagger

API Endpoints

Method          Endpoints         Description
GET             /employees        List all employees
GET             /employees/{id}   Get employee by id
Post            /employees        Create employee
PUT             /employees/{id}   Update employee
DELETE          /employees/{id}   Delete employee

Health Check

  Get /health

Used for container orchestration and monitoring

Architecture

This project follows Clean Architecture principles:

  Domain
  Application
  Infrastructure
  API

Responsibilites are separated to improve maintainability and scalability.

Author

Patrick Machado
Fullstack Developer