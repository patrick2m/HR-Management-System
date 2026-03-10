Projeto front e backend, para estudo de caso com .net, React, Docker, Kubernetes e Kafka

Comandos utilizados :

-Download de repositório vazio:
git clone https://github.com/patrick2m/hr-management-system
cd hr-management-system
mkdir backend
mkdir frontend

-Criação de projeto base backend
cd backend
dotnet new sln -n HRManagement
dotnet new webapi -n HR.API
dotnet new classlib -n HR.Domain
dotnet new classlib -n HR.Application
dotnet new classlib -n HR.Infrastructure

-Adição de projetos na solution
dotnet sln add HR.API
dotnet sln add HR.Domain
dotnet sln add HR.Application
dotnet sln add HR.Infrastructure

-Adição de referências entre projetos
dotnet add HR.API reference HR.Application
dotnet add HR.API reference HR.Infrastructure
dotnet add HR.Application reference HR.Domain
dotnet add HR.Infrastructure reference HR.Domain

-Instalar pacotes
cd HR.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
cd..
dotnet add HR.API package Swashbuckle.AspNetCore

dotnet tool install --global dotnet-ef











