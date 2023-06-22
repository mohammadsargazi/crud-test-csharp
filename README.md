# Customer Management System

Overview
This project is a Customer Management System developed using .NET Core and following the principles of Domain-Driven Design (DDD). 
It provides a set of CRUD (Create, Read, Update, Delete) operations for managing customer information. 
The system includes features such as storing customer details, performing validations, and integrating with external systems using MediatR and CQRS (Command Query Responsibility Segregation) patterns
. Integration tests are also included to ensure the system's functionality.

Project Structure
The project follows a modular structure to adhere to DDD principles. Here is a brief overview of the main directories:

- Domain: Contains the core domain models and business logic and commands used for CQRS.
- Application: Contains application services.
- Infrastructure: Includes infrastructure-related implementations like database repositories and message handler.
- Api: Provides the API controllers and routes for handling HTTP requests.
- Tests: Contains integration tests.


