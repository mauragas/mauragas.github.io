# Design patterns

## Adapter

## Bridge

## Builder

## Chain of Responsibility

## Command

## Composite

## Decorator

## Facade

## Factories

## Flyweight

## Interpreter

## Iterator

## Mediator

## Memento

## Null object

Using this pattern you can eliminate the need for null checks.

### Problem

When we are adding null checks we are increasing code complexity and potentially violating Liskov Substitution Principle (LSP).

Example of method with argument null check:

```csharp
public void AddEmployee(Employee employee)
{
  if (employee is null) throw new ArgumentNullException();
  if (employee.Name is null) throw new ArgumentNullException();
  if (employee.Surname is null) throw new ArgumentNullException();
  // ...
}
```

Complexity of the method increases every time we are new null check.

### Solution

Solution to the problem is to add default object value (e.g. NullEmployee). Common practice is to use inheritance or add general interface (e.g. IEmployee) and call default implemented methods for each class.

When implementing interface we can provide `default` values instead of throwing exception or returning null value:

```csharp
public class NullEmployee : IEmployee
{
  public string Name => "Unknown";
  public string Surname => "Unknown";
}
```

Advantage of having null object value is that we can return it (e.g NullEmployee) and we do not need to have null checks in fallowing methods because returned object is not null anymore.

## Observer

## Prototype

## Proxy

## Singleton

Singleton is a component which is instantiated only once.
Motivation for the singleton pattern is that sometimes we need only one instance of the object (e.g. HttpClient) in all application, therefore we can reuse it as much as possible instead of initializing it every time. Main use case is when creating object in the program is expensive. And we need to prevent anyone in the program create more that one object.

### Building singleton

To create our own singleton class we can by hard coding static reference to the instance. And to ensure that class is initialized only when it is needed we can use `Lazy` loading:

```csharp
private static Lazy<SingletonClass> _instance =
  new Lazy<SingletonClass>(() => new SingletonClass());

public static SingletonClass Instance => _instance.Value;
```

The issue occurs when we need to tests class which is using singleton, because it will have hard coded static instance call, therefore we will not be able to mock it. We can solve it with dependency injection.

### Using dependency injection

Best practice of creating singleton is just configure dependency container to inject single object instead of building it. Therefore we can solve issue with testability and avoid using static fields in the class.

For example you can use [Autofac](https://github.com/autofac/Autofac) dependency container to create singleton:

```csharp
var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterType<SingletonClass>()
  .As<ISingletonClass>()
  .SingleInstance();
var container = containerBuilder.Build();
```

Then we can get singleton type of ISingletonClass anywhere through constructor parameter.

## Specification

## State

## Strategy

## Template Method

## Visitor
