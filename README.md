# Product-management-Tool
Design justification :
Scalability & Flexibility:
    The database and class design support dynamic categories and attributes, allowing easy addition of new product types in the future without changing the schema.
Normalization & Data Integrity:
   Each entity (Category, AttributeDefinition, Product, ProductAttributeValue) is stored in its own table to avoid redundancy and maintain data consistency.
Separation of Concerns:
  Layered architecture (Repositories, Services, DTOs) ensures that database operations, business logic, and user input are separated, improving maintainability and testability.
Reusability & Extensibility:
  Services and repositories are reusable across different operations, and adding new features (e.g., new reports or attributes) requires minimal code changes.
Simplicity for Demonstration:
  Console app allows easy demonstration of CRUD operations and database interactions without the overhead of UI/UX, focusing on core functionality.
