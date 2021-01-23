# Design patterns

Patterns are guides for software design but not strict implementation rules, therefore patterns can have many different variations with own pros and cons.

Design patterns are split into three categories:

- Creational - instead of instantiating objects with `new` operator, design pattern provides a way to hide creation logic. It gives controls how objects are created for a given use case.
- Structural - utilizes class and object composition through inheritance.
- Behavior - utilizes communication between objects.

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

Design pattern `state` is about the condition of something variable, object behavior is determined by its state.

- State - defines state of an object at any given time (e.g. button is `on` or `off`).
- Trigger - it is something what starts the state transition in a state machine.
- Transition - change of state caused by event.
- Event - it is action which is performed by state machine when particular state is completed.
- Guard condition - it is condition which validates the transition.
- State machine - construct which manages states and transitions (e.g. class).

This pattern solves two design challenges:

- How can an object change its state behavior when its internal state changes.
- How can state specific behaviors can be defined so that state can be added without changing the behavior of existing state.

Changes in state can be explicit or in response to event.

You can define:

- Sate entry or exit behavior.
- Transition event caused by action.
- Guard condition which is enabling or disabling transaction.
- Default action when there is no event for transaction.

### Constructing state machine

For constructing state machine you can use enums which defines button state and triggers:

```csharp
public enum State
{
  On,
  Off,
  // ...
}
public enum Trigger
{
  Toggle
  // ...
}
```

Using enums and dictionary with rules you can construct basic state machine class:

```csharp
public class StateMachine
{
  private static Dictionary<State, List<(Trigger, State)>> Rules
    = new Dictionary<State, List<(Trigger, State)>>
    {
      [State.Off] = new List<(Trigger, State)>
      {
        (Trigger.Toggle, State.On)
      },
      [State.On] = new List<(Trigger, State)>
      {
        (Trigger.Toggle, State.Off)
      }
    };
}
```

### Constructing state machine using abstract classes

We can achieve it by encapsulating state specific behavior within separate state objects, by using a class to delegate the execution of its state specific behavior to one state object at a time. It requires structure code using abstract and concrete classes as a states.

It contains three components:

- **Context** - is a class which maintains an instance of a current state and can set a state. It maintains reference to one of the concrete states as its current state through abstract state class.
- **Abstract state** - abstract class which encapsulates state specific behavior.
- **Concrete state** - any number of subclasses of abstract class which implements behavior specific to a particular state of context. Concrete state class derives from abstract state class and implements specific behavior.

To start implementing state pattern approach you need to list of possible states, conditions for transitioning between those states and initial state.

#### Example of button state machine

To construct state pattern for button we can define one class for context, one abstract class and two concrete state classes.

Context class:

```csharp
public class ButtonContext
{
  private ButtonState _currentState;

  public ButtonContext()
  {
    // Initial state is set to off
    TransitionToState(new OffState());
  }
  public void TransitionToState(ButtonState state)
  {
    _currentState = state;
    _currentState.Toggle(this);
  }
}
```

Abstract state class:

```csharp
public abstract class ButtonState
{
  public abstract void Toggle(ButtonContext button);
}
```

Concrete state classes:

```csharp
public class OffState : ButtonState
{
  public override void Toggle(ButtonContext button)
  {
    // Logic for On state
  }
}
  public class OnState : ButtonState
{
  public override void Toggle(ButtonContext button)
  {
    // Logic for Off state
  }
}
```

### State machine libraries

Usually to construct state machine you can utilize existing libraries like:

- [Stateless](www.nuget.org/packages/Stateless)
- [NState](www.nuget.org/packages/NState)
- [Automatonymous](www.nuget.org/packages/Automatonymous)

Example of using **Stateless** library:

```csharp
var stateMachine = new StateMachine<State, Trigger>(State.Off);

// Specify a valid state transition based on a trigger
stateMachine.Configure(State.Off).Permit(Trigger.Toggle, State.On);
stateMachine.Configure(State.On).Permit(Trigger.Toggle, State.Off);

// Start transaction (trigger is fired)
stateMachine.Fire(Trigger.Toggle);
```

## Strategy

Main goal of the pattern is that we can select implementation at runtime (dynamic) or compile time (static) based on input without having to extend the class, therefore you can partially define behavior of the system and later change it. It is one of the most commonly used pattern.

Pattern can be identified by three characteristics:

- Context - has a reference to a strategy and can invoke it.
- IStrategy - definition of interface (contract) for the strategy.
- Strategy - implementation of the strategy.

Strategy interface is used to be able easily extend application with additional strategies without affecting current implementations.

### Example

To utilize strategy pattern as example we can create a **list** strategies for two different formats **markdown** and **html**.

Strategy interface:

```csharp
public interface IListStrategy
{
  string Append(string existingList, string item);
}
```

Concrete implementations of interface for **markdown** and **html** strategies:

```csharp
public class MarkdownListStrategy : IListStrategy
{
  public string Append(string existingList, string item)
  {
    return $"{existingList}{Environment.NewLine} * {item}";
  }
}

public class HtmlListStrategy : IListStrategy
{
  public string Append(string existingList, string item)
  {
    // Not a full implementation for simplicity of example
    return $"{existingList}{Environment.NewLine}<li>{item}</li>";
  }
}
```

Static strategy context implementation:

```csharp
public class TextProcessorContext<ListStrategy>
  where ListStrategy : IListStrategy, new()
{
  private string _list = string.Empty;
  private IListStrategy _listStrategy = new ListStrategy();

  public void AppendToList(IEnumerable<string> items)
  {
    items.ToList().ForEach(item => _
      list = _listStrategy.Append(_list, item));
  }

  public override string ToString()
  {
    return _list;
  }
}
```

Context class implementation can be changed to dynamic composition by using **dependency injection** when concrete strategy implementation is injected at runtime instead of using generic class.

Example of usage:

```csharp
var textProcessor = new TextProcessorContext<MarkdownListStrategy>();
textProcessor.AppendToList(new[] { "one", "two", "three" });
WriteLine(textProcessor);
```