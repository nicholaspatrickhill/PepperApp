**PepperApp** was created by Nick Hill in 2023 as a capstone project for Code Kentucky's Software Development Course 2.
The application helps users manage information about hot peppers and their Scoville Heat Unit ratings, making it easy to recall, update and maintain this data.

### ARCHITECTURE
PepperApp uses Entity Framework to manage connections to a sqlite database.
The Services/Repository pattern and a Data Transfer Object (DTO) are employed to seperate concerns.
These abstractions limit exposure to the database, which makes the code more secure and easier to maintain.
The services handle logic and validation while the repository addresses data storage and retrieval.
The DTO decouples the data model from the other layers of the project, making it easier to test.

The use of these patterns also facilitates the creation of two, independent applications that can interact with the data: 
- A CRUD API with a Swagger UI that allows users to interact with the database through a web browser.
- A console application that enables users to perform CRUD operations on the database based on input received from the console.

### FEATURES
The following items from the Feature List are implemented:
- Create 3 or more unit tests for your application.
- Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program.
- Implement a log that records errors, invalid inputs, or other important events and writes them to a text file.
- Make your application an API.
- Make your application a CRUD API.
- Make your application asynchronous.
- Query your database using a raw SQL query, not EF.

### DEPENDENCIES
PepperApp uses several libraries including AutoMapper, Serilog, FluentValidation, Swashbuckle and Entity Framework Core.
The package references are in the corresponding project files.
Please restore the packages through NuGet or through dotnet CLI by running dotnet build and dotnet run.

### USAGE
To use PepperApp, follow these steps:

1. Clone the repository to your local machine.
2. Restore the NuGet packages.
3. Run the application using either the Swagger UI or the Console Application.
4. Use the API endpoints or the Console Application to perform CRUD operations on the database.