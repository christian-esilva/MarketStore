# NerdStore-Dominios-Ricos

## DDD
Domain-Driven Design (DDD) is a software development approach that emphasizes understanding the domain (the area of expertise or activity) in which an application operates. It focuses on aligning the software’s design and code with the business logic, rules, and requirements of the domain.

(Através do conhecimento do domínio é possível facilitar a implementação de complexas regras / processos de negócio.)

- Ubiquitous Language
  
All stakeholders (developers, business analysts, domain experts, etc.) should use the same language when discussing the system. This shared vocabulary is called the ubiquitous language, and it helps ensure everyone has a clear understanding of the domain and how it’s represented in the system.
-  Domain Model

The domain model is a conceptual representation of the domain’s entities, relationships, and behaviors. It’s the heart of the DDD approach and helps to structure and organize the code around the domain’s real-world processes.
Como Funciona o Domain Model?
Imagine que você está desenvolvendo um software para gerenciar uma loja online. O modelo de domínio vai representar os principais conceitos da loja, como Clientes, Pedidos, Produtos, Pagamentos, etc. Ele tenta refletir da forma mais fiel possível como esses elementos existem e interagem no mundo real, mas adaptados ao contexto do software.
- Bounded Context

In complex systems, different parts of the application might deal with distinct parts of the domain. A bounded context is a boundary within which a particular domain model is valid. Different bounded contexts can have different models and interpretations of terms and processes.
- Entities and Value Objects
  
Entities are objects with a unique identity that persists over time. For example, a "Customer" is an entity because two customers can have the same name but are still distinguishable by their unique identity (like an ID).
Value objects, on the other hand, are objects that don’t have a unique identity. They are defined solely by their attributes. An example is a "Money" object, which can be $10, regardless of its origin.
- Aggregates and Aggregate Roots
  
An aggregate is a cluster of related entities and value objects that are treated as a single unit for data changes. The aggregate root is the main entity that manages the consistency and business rules for its aggregate. For example, an "Order" can be an aggregate root that contains order items.
- Repositories
  
Repositories are responsible for encapsulating the logic for retrieving and storing aggregates. They allow the rest of the application to remain focused on business logic without worrying about data persistence.
- Services
  
In DDD, a service represents an operation that doesn’t naturally belong to an entity or value object. It typically encapsulates domain logic that applies to multiple domain models.
- Factories
  
Factories are used to create complex aggregates. Instead of having logic for creating an entity scattered throughout the system, the factory centralizes this creation logic.
- Event-Driven Design
  
DDD often incorporates event-driven design, where certain actions in the system generate domain events, which other parts of the system can react to.

## CQRS

Command Query Responsibility Segregation (CQRS)
It is the segregation of responsibilities between reading and writing.
'Command' represents an intent to change/write data to the database, and 'Query' represents reading data from the database.
With CQRS, we will have distinct databases for reading and writing, which will be synchronized at some point. In other words, this involves eventual consistency – at some point, the data in the read database will be different from the data in the write database.

You can also have more than one write database, according to the 'bounded context,' meaning based on the delimited context for a certain 'sector.'
The read database, however, is typically just one.

* Why use CQRS?
  
CQRS is recommended for applications that will have a high volume of data traffic, meaning applications with high demand for reading and writing data (many active users simultaneously), and which aim to maintain high availability even under such high demand (no timeouts, no deadlocks, etc.).
