# SOLID Principle

SOLID is acronym for 5 object orient programming principles which should help you create more easily testable and maintainable solutions.

When you are considering whether to apply any of SOLID principles, you should practice Pain Driven Development (PDD). You should start writing simplest technique possible to solve the problem, you should not try apply all principles at the beginning of development, avoid premature optimization of your application design. After application grows you should search for places in application where it is "painful" to work with and therefore apply SOLID principles to relief the "pain" and improve design. The referred "pain" is difficulty of testing, code coupling, duplication and etc.

## Single Responsibility Principle (SRP)

Each software module (e.g. class or method) should have one and only one reason to change (responsibility).

Each application class and method defines its behavior, **what** and **how** it is executing. Application design can be improved by separating **what** from the **how**, by using delegation or encapsulation. Classed should encapsulate single responsibility, therefore it is clear what is its purpose. By using other classes you can delegate operations, where each class encapsulates its own specific responsibility.

When classes are doing too much at the same time, usually it is coupling too many unrelated things and making it much harder to use. Trying to make multi purpose class or method adds unnecessary complexity.

### Responsibility or reason to change

Responsibility is decision of code making about the specific implementation details of some part of application behavior. Responsibility is the reason why class or method needs to change or a part of code needs to do about specific implementation details of some part of application. When you have several responsibilities you are also can do several tasks or changes at once.

Examples of responsibilities:

- `Validation` - how input is validated.
- `Persistence` - data which ensures application persistence.
- `Business logic`- how business requirements are ensured.
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



## Liskov Substitution Principle (LSP)



## Interface Segregation Principle (ISP)



## Dependency Inversion Principle (DIP)
