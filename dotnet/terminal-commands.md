# Terminal commands

Common dotnet terminal commands for project or solution creation, build, publis and etc.

## Documentation

[Dotnet commands](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet)

## Get help

```bash
dotnet help
```

## Create

Build new WEB application and run it

```bash
dotnet new web
dotnet build
dotnet run --urls="http://localhost:10000"
```

Create new console project

```bash
dotnet new console -o `project-name`
```

Create solution file

```bash
dotnet new sln
```

Add project to solution file

```bash
dotnet sln `solution-file.sln` add `./path/to/project/file`
```

## Build and publish

Build a single-file executable

```bash
dotnet publish -r ubuntu.19.10-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
dotnet publish -r win-x64 -c Release --self-contained
```

Specify to build single file in project file

```xml
<PropertyGroup>
  <PublishSingleFile>true</PublishSingleFile>
  <PublishTrimmed>true</PublishTrimmed>
  <RuntimeIdentifier>ubuntu.19.10-x64</RuntimeIdentifier>
</PropertyGroup>
```

Publish application using profile file

```bash
dotnet build MyPreject.csproj /p:DeployOnBuild=true /p:PublishProfile=`./path/to/profile/file`
```

## Templates

[Available templates](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)

List all installed templates

```bash
dotnet new -u
```

Install default or preview Blazor template

```bash
dotnet new -i "Microsoft.AspNetCore.Blazor.Templates::*"
dotnet new -i "Microsoft.AspNetCore.Components.WebAssembly.Templates::3.2.0-preview*"
```

