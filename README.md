# Product-management-Tool
Approach:

I chose to implement the tool as a C# Console Application to keep it simple and focus on demonstrating database design, class design, and core functionality.
The application uses SQL as the database and Entity Framework Core for ORM. It follows layered architeture

Models: Representing database entities (Category, Product, Attributes, Attribute Values).

Repositories: Handling database operations (CRUD) for each entity.

Services: Containing business logic and interacting with repositories.

DTOs: Used for data transfer between services and the console input.

Utils/Input Helpers: For validating and reading user inputs.

The tool supports:

Creating and managing product categories.

Adding category-specific attributes.

Creating products and assigning attribute values dynamically.

Listing products with their categories and attributes.

I did not include any UI/UX designs since the main focus was on backend design, database integration, and functionality.

The console menu demonstrates CRUD operations clearly and can be extended easily for future features or additional categories.


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
