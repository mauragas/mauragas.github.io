# Entity Framework

It is an object-relational mapper that enables you to work with relational data using domain-specific objects.

Entity framework CLI tool `dotnet-ef` or `dotnet ef` can be installed with the [command](https://docs.microsoft.com/en-au/ef/core/cli/dotnet#installing-the-tools):

```bash
dotnet tool install --global dotnet-ef
```

Tool can be updated to newest version:

```bash
dotnet tool update --global dotnet-ef
```

## SQLite database

You can use SQLite database files with Entity Framework.

### Scaffold local database file

You can [scaffold](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli#connection-string) SQLite local database file with Entity Framework Core.

Add NuGet packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design &&
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

Start scaffold:

```bash
dotnet ef dbcontext scaffold "DataSource=path/to/database.sqlite3" Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models
```

**NOTE:** You need run command inside project folder or specify project path with `-p`.

### Scaffold using named connection strings

Named connection strings are only supported when using `IConfiguration` and a service provider.

[Enable secret storage](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=linux#enable-secret-storage) which will be used to store connection string:

```bash
dotnet user-secrets init
```

**NOTE:** Secret ID `UserSecretsId` will be added to project file. Secret file can be found in directory `~/.microsoft/usersecrets/<user-secrets-id>/secrets.json`.  

Add [ConnectionString](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings) to secret storage:

```bash
dotnet user-secrets set ConnectionStrings.TestDatabase "DataSource=path/to/database.sqlite3"
```

Start scaffold:

```bash
dotnet ef dbcontext scaffold Name=ConnectionStrings.TestDatabase Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models
```

### Migrations

If you use code first approach, you can [apply migration](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli) tool to create database file. In case database already exist remove it and use migration tool to create new one:

```bash
dotnet ef migrations add InitialCreate &&
dotnet ef database update
```

If you change any model classes you can similarly update database tables:

```bash
dotnet ef migrations add TestMigration &&
dotnet ef database update
```
