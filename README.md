# SharedKernel.Domain

A foundational framework for implementing **Domain-Driven Design (DDD)** principles in .NET.  
Helps build clean, independent, and scalable Domain Models.

---

## Features

- Base components for Entities, Value Objects, and Aggregate Roots  
- Clear separation of domain logic from infrastructure  
- Easy to extend for repositories and domain services  

---
## Installation

```
dotnet add package Behtash.SharedKernel
```
## Getting Started

### Prerequisites

- .NET 8.0 or later  
- Familiarity with Domain-Driven Design concepts  

### Usage

Add the project to your solution or install via NuGet .

Example Entity:

```csharp
public class Customer : Entity<Guid>
{
    public string Name { get; private set; }
    public Customer(Guid id, string name) : base(id)
    {
        Name = name;
    }
}
