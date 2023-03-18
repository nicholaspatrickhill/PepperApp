**PepperApp** is my capstone project for Code Kentucky's Software Development Course 2.
PepperApp was developed to help me manage information about hot peppers and their Scoville Heat Unit ratings.
I grow hot peppers and make hot sauce and other pepper products and am constantly seeking out this information from various sources.
PepperApp helps me quickly recall, update and maintain this data.


### FEATURES
The following items from the Feature List are implemented:
- Create 3 or more unit tests for your application
- Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
- Implement a log that records errors, invalid inputs, or other important events and writes them to a text file
- Make your application an API
- Make your application a CRUD API
- Make your application asynchronous
- Query your database using a raw SQL query, not EF

### NOTES
PepperApp uses Entity Framework to manage connections to a sqlite database.
The database is seeded at creation by a dictionary containing several, protected (read-me) entries.
Seperation of concerns is handled bu utilizing a Services/Repository pattern and a Data Transfer Object (DTO).
The services handle logic and validation while the repository handles data storage and retrieval.
The DTO decouples the data model from the other layers of the projects and the unit tests.
CRUD operations are provided for the entities that are managed by the repository.

The services/repository pattern afforded me the opportunity to create two, independent applications.
One is a CRUD API with a Swagger UI that allows the user to interact with the database over the web.
The second is a Console application that performs the same functions based on user input.

### DEPENDENCIES
PepperApp uses several libraries including AutoMapper, Serilog, FluentValidation and Entity Framework Core.
Package references are in the project files.
Please restore the packages through NuGet (if it wasn't set to do so automatically) or through dotnet CLI by running dotnet build and dotnet run.