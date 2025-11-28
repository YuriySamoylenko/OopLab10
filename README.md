# Apartment Management System (OOP Lab Project – Part C)

**Language:** C# (.NET 8)  
**Paradigms Demonstrated:** Object-Oriented Programming (Inheritance, Polymorphism, Encapsulation, Abstraction)  

---

### Project Overview

This console application simulates an **apartment management system** where users can:
- Create apartments with a customizable number of bedrooms
- Automatically or manually furnish rooms
- Use furniture (polymorphic behavior)
- Move furniture to different walls (North, South, East, West)
- Remove furniture and apartments
- View the current state of all apartments

The project is a **demonstration of core OOP principles** with real-world meaning and clean, testable architecture.

---

### OOP Concepts Implemented

| Concept                | Implementation                                                                 |
|------------------------|----------------------------------------------------------------------------------|
| **Inheritance**        | `Furniture` ← `Bed`, `Chair`, `Table` <br> `Room` ← `Bedroom`, `Kitchen`, `Bathroom` |
| **Polymorphism**       | `Use()` method returns different messages per furniture type <br> `AddFurniture()` overridden in `Bathroom` and `Kitchen` to reject beds |
| **Encapsulation**      | Private fields, public properties, `protected` constructors and members         |
| **Abstraction**        | `abstract class Furniture`, `abstract class Room`, interfaces `IFurniture`, `IUsableFurniture` |
| **Interface Segregation** | Separate interfaces: `IFurniture` (movement), `IUsableFurniture` (usage)      |
| **Liskov Substitution** | Any `Room` can be used where `Room` is expected — behavior differs safely       |
| **Composition & Aggregation** | `Apartment` contains `Room`s (aggregation) <br> `Room` contains `Furniture` (composition) |

---
