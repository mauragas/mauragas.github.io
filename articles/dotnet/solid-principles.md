# SOLID Principle

SOLID is acronym for 5 object orient programming principles which should help you create more easily testable and maintainable solutions.

When you are considering whether to apply any of SOLID principles, you should practice Pain Driven Development (PDD). You should start writing simplest technique possible to solve the problem, you should not try apply all principles at the beginning of development, avoid premature optimization of your application design. After application grows you should search for places in application where it is "painful" to work with and therefore apply SOLID principles to relief the "pain" and improve design. The referred "pain" is difficulty of testing, code coupling, duplication and etc.

## Single Responsibility Principle (SRP)

Each software module (e.g. class or method) should have one and only one reason to change (responsibility).

Each application class and method defines its behavior, **what** and **how** it is executing. Application design can be improved by separating **what** from the **how**, by using delegation or encapsulation. Classed should encapsulate single responsibility, therefore it is clear what is its purpose. By using other classes you can delegate operations, where each class encapsulates its own specific responsibility.

When classes are doing too much at the same time, usually it is coupling too many unrelated things and making it much harder to use. Trying to make multi purpose class or method adds unnecessary complexity.

### Responsibility or reason to change

Responsibility is decision of code making about the specific implementation details of some part of application behavior. Responsibility is the reason why class or method needs to change or a part of code needs to do about specific implementation details of some part of application. When you have several responsibilities you can also do several tasks or changes at once.

Examples of responsibilities:

- `Validation` - how input is validated.
- `Persistence` - data which ensures application persistence.
- `Business logic` - how business requirements are ensured.
- `Logging` - various records of application process.

Each responsibly during software development can change at different times, for example persistence can change from using files to database.

Responsibilities in code may change at different times and for different reasons.

### Tight and loose coupling

Single responsibility principle is related to tight coupling. It is when two or more details are bind together in a way that it is difficult to change. Loose coupling is when details of application are interacting with each other in modular fashion, when class responsible for higher lever responsibility is delegating lower level operations to other classes. Loose coupled code is preferred because it is easier to change and test.

#### Separation of concerns

Concerns are separated when the program is split into distinct section, each addressing a separate concern or set of information that is affecting the program. High level code should not know about details of low level code implementations, therefore high level code is is not tightly couplet to specific low level details.

#### Cohesion

Cohesion describes how closely modules or elements are related to each other. Classes which have many responsibilities are less cohesive. To make classes more cohesive you need to split code into separate classes with less responsibilities.

## Open Closed Principle (OCP)

Software entities (e.g. modules, classes, methods and etc.) should be `open` for extension but `closed` for modification. It should be possible to change the behavior of the method without modifying its source code.

- Open to extension - means that it is easy to add new behavior. If module is closed for extension, means it has a fixed behavior.
- Closed for modification - means that it is not required to modify source or binary code to add new behavior.

Benefits:

- Less we change source code, less likely we will introduce new bugs.
- No need to redeploy, therefore reduces risk of downtime and reduces impact of down stream dependencies.
- Simpler code due to reduced count of conditional operations.
- We can ignore this principle in bug fixes when it is necessary.

You should balance abstraction and concreteness, because abstractions adds complexity. When module does one specific thing, it does not have abstraction, it is fully concrete. Module should have flexibility, therefore it can be extended in the process of maintainability when new requirements are introduced. We should predict where code in the future could be extended and apply abstraction as needed. But we should not implement abstractions in all possible places, because code can become too complex and difficult to work with.

When we use `new` keyword we are glueing variables to concrete implementation.

Approaches for applying OCP:

- Parameters - by passing different arguments to the methods we can change its behavior.
- Inheritance - you can change behavior using child class. Therefore you can `override` parent `virtual` methods or add your own.
- Composition and injection - logic is provided by another type class is referencing. Instead hard coding references, it can be provided through dependency injection.
- Extension methods - ability to add additional methods to types without modifying types itself.

Prefer implementing new features in new classes, especially in large legacy code base. If class is new, nothing depends on it and you can design it to suit the problem without touching existing code, making it fully testable and follow SRP.

Process steps of implementing OCP:

- Start developing simple and concrete solution.
- After some modifications consider where code should be made open for extension. Detect places where application is likely continue to need changes.
- Modify application to be extensible without the need to modify its source code.

## Liskov Substitution Principle (LSP)

Subtypes must be substitutable for their base types.

Basic object oriented design often describes two relationships:

- Relationship `is-a` (e.g. eagle is a bird)
- Relationship `has-a` (e.g. car has the engine)

LSP states that the `is-a` relationship is insufficient and should be replaced by `is-substitutable-for`.

### Rectangle and square problem

A rectangle has four sides and four right angles, but square have all four sides equal length. In geometry we say that square `is a` rectangle. Therefore we can create create class **Square** which inherits from **Rectangle**. We can ensure square that height and width are equal when one value set, other is set to the same value too. The problem occurs when we expect to work with rectangle but square instance is used instead:

```csharp
Rectangle rectangle = new Square();
rectangle.With = 2;
rectangle.Height = 4;

Assert.That(AreaCalculator.GetArea(rectangle), Is.EqualTo(8));
// Test fails because actual calculated area is 16
```

In given example it is obvious that we instantiating Square with the `new` keyword, but in case we pass to the method parameter Square object when we expect Rectangular, it will be not so clear where the problem is. Current design approach breaks **invariants** for rectangles that its sides are independent, where square sides must be equal. This violates LSP, the square is not substitutable for rectangle everywhere rectangle is used.

Solution to this problem would be:

- Use boolean in the class to note if rectangle is as square.
- Defined separate class for square with only side property, instead of height and length.

### LSP violations

- In case of type checking with keywords `is` or `as` in polymorphic code. Solution could be to dedicate separate class to perform specific action or write common method for all classes (e.g. ToString() method).
- Null checks, which is similar to type checking. Solution could be to use **null object design pattern**.
- Exception thrown from methods when is not implemented (e.g. NotImplementedException). Happens when interface or base class is not fully supported, therefore it is not fully substitutable for where its interface or base class can be called. This usually violates ISP too.

## Interface Segregation Principle (ISP)

Describes how we should design and use interfaces in our applications. Clients should not be forced to depend on methods they do not use. You should use small cohesive interfaces instead of large ones.

## Interface and clients

Interface is public interface of a class, it is whatever can be accessed by client code working with an instance of that type.
Client (plugin for interface) is a code which is interacting with the interface.

## Detecting violations

Violations of this principle results into classes that dependents on things they do not need and therefore it increases coupling and makes it harder to change, difficult to test and more difficult to deploy due to increased size of downstream dependencies.

Indications of ISP violations:

- Large interfaces.
- Not implemented exceptions thrown from the methods.
- Client code uses only small part of the large interface.

Interface segregation principle is related to LSP, large interface full implementation is harder, therefore causing partial implementation and thus not be fully substitutable for their base type.
ISP also relies on cohesion and SRP, small and cohesive interfaces are more preferable.

## Fixing violations

- Break large interface into smaller ones where applicable. If large interface is still used you can compose it using interface inheritance with smaller ones for backward compatibility.
- In case you use interface you cannot control - create a small and cohesive interface and fallowing **adapter design pattern**. You should work with adapter interface you can control and adapter internally can work with larger interface. Only adapter should know about large interface.
- Client code should own and define their interfaces.
- Interfaces should be declared in shared project where both client code and implementations can access.

## Dependency Inversion Principle (DIP)

Allows to create loosely coupled and maintainable software of any size. Principle states that high level modules should not depend on low level modules, but both should depend on abstractions. Abstractions should not depend on details, but details should depend on abstractions.

### Dependencies

There is runtime and compile time. DIP mostly related to compile time dependencies. Project references must point to direction of your dependencies, references should point away from low level infrastructure code and toward high level abstraction and business logic.

- High level constructs - more abstract, process oriented, contains business rules, further away from inputs and outputs.
- Low level constructs - closer to inputs and outputs, interacts with external systems and hardware devices.

DIP is about separation of concerns, it refers to specific form of decoupling of software modules. It helps to develop loosely coupled code by ensuring that high level modules depends on abstractions rather than concrete implementations.

Abstractions are types you can not instantiate:

- Interfaces - are preferred because does not require object inheritance.
- Abstract base classes.

Abstractions define a contract without specifying how work is going to get done. Abstractions should not be coupled to details, therefore it should not know how it should be implemented. It only defined `what` needs to happen, but details specify `how` it should be implemented.

Low level dependency examples:

- File system
- Email
- Database
- Web API
- Configurations details
- System clock

Hidden direct dependencies usually are static calls, usage of `new` keyword and direct use of low level dependencies. These dependencies introduces tight coupling and duplications. Because it is not injected into class it is much harder to unit test.

### Explicit dependencies principle

Principle states that class should explicitly require their dependencies through constructor. This ensures software developer working with the class what dependencies are used when class is instantiated.

Dependencies also can be injected throw properties or method arguments. Dependency injection technique is implementation of **strategy design pattern**.

### Compile time and runtime dependencies

When using dependencies with interfaces (loose coupling introduced) on compile time dependencies are inverted (classes are pointing back to interfaces). All classes depends on interfaces instead of concrete implementations. And at runtime system behavior remains same. Therefore it makes easier to swap implementations in the future.

![Inverted dependency graph](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/media/image4-2.png)

## Other sources

[Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
