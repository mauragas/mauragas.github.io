# Design patterns

Design patterns are split into three categories:

- Creational -
- Structural -
- Behavior -



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

Prototype is creational design pattern. It defines prototype objects which can make deep copy of itself. It is used when it is easier to copy an existing object instead of fully initializing new one. Motivation for this pattern is that complicated object (e.g. Mobile phones) usually are not designed from scratch but from existing prototype, existing design usually is reiterated with new versions or different variations. Prototype is partially or fully constructed object. We can make a copy the prototype and customize it later. To make copying more convenient we can provide Factory design pattern.

- Shallow copy - copying object reference.
- Deep copy - copying object and all its references, therefore changing a copy does not change original object.

### Copy constructor

We can define separate constructor which takes same object through parameter to make deep copy of itself:

```csharp
class Car
{
  public Car(Car car)
  {
    // Map each values
  }
}
```

In this approach we will need to create for each used class a copy constructor and map each value manually.

### Using interface

We can create own interface which explicitly says to implement deep copy method:

```csharp
public interface IPrototype<T>
{
  T DeepCopy();
}
```

In this approach we will still need manually map each values and implement interface for each used class.

### Serialization

To make deep copy of an object we can use serialization, therefore we will not need to depend on copy constructor or interface. To make serialization to work in any object we can create extension method:

```csharp
public static class Extensions
{
  public static T DeepCopy<T>(this T self)
  {
    using var stream = new MemoryStream();
    var formatter = new BinaryFormatter();
    formatter.Serialize(stream, self);
    stream.Seek(0, SeekOrigin.Begin);
    return (T)formatter.Deserialize(stream);
  }
}
```

Any class what you want to serialize you need to make it serializable with attribute `[Serializable]`. To avoid using this attribute you can use different formatter like XmlFormatter, but in this case you will need to define default empty constructors for each class.

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
