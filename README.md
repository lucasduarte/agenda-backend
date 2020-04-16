# Agenda Backend

## Bibliotecas Utilizadas
- .NET Core 3.1
- Microsoft.AspNetCore.Cors
- Microsoft.AspNetCore.Mvc.NewtonsoftJson
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.EntityFrameworkCore.Relational

## Banco de Dados
Foi utilizado o banco de dados InMemory e foram adicionados seeds iniciais para as tabelas que não possuem CRUD

## Passos para executar o projeto

### Primeiramente deve entrar no projeto Agenda.API e instalar os packages
```
dotnet restore
```

### Compila e roda o projeto na porta 5000 (http) e 5001 (https)
```
dotnet run
```
