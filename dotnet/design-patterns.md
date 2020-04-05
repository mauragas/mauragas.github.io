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

## Specification

## State

## Strategy

## Template Method

## Visitor
