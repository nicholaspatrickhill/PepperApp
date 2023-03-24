**PepperApp** was created in 2023 as my capstone project for Code Kentucky's Software Development Course 2.

### DESCRIPTION
PepperApp helps users manage information about hot peppers and their Scoville Heat Unit ratings, making it easy to recall, update and maintain this data.
Hot pepper enthusiasts and hot sauce artisans may find it useful for storing and updating information about their favorite peppers or for discovering new varities to try in their recipes.

### ARCHITECTURE
PepperApp uses Entity Framework to manage connections to a sqlite database.
The Services/Repository pattern and a Data Transfer Object (DTO) are employed to separate concerns.
These abstractions limit exposure to the database, which makes the code more secure and easier to maintain.
The services handle logic and validation while the repository addresses data storage and retrieval.
The DTO decouples the data model from the other layers of the project.

The use of these patterns facilitates the creation of two, independent applications that can interact with the data: 
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
Please restore the packages by right-clicking the solution in the Solution Explorer and selecting 'Restore NuGet Packages' from the context menu.

### USAGE
To use PepperApp, follow these steps:
1. Clone the repository to your local machine.
2. Restore the NuGet packages.
3. To use the API with Swagger UI, right-click the PepperApp.API project in the Solution Explorer and select "Set as StartUp Project" from the context menu.
4. To use the console application, right-click the PepperApp.ConsoleApp project in the Solution Explorer and select "Set as StartUp Project" from the context menu.
5. Build and run the project after the proper startup project has been set.
6. Use the API endpoints or the Console Application to perform CRUD operations on the database.

### CONSOLE APPLICATION
The console application is designed around a main menu that is navigable by using the UP and DOWN arrow keys.
Users are given options to view all peppers in the database; view only peppers within a selected heat class; view a single pepper by name; add, update or remove pepper entries; or to save a list of all of the peppers in the database to a text file.
The console application guides users through these functions and receives input to update the database accordingly.
When finished, users may terminate the application by selecting exit and pressing enter.

### API ENDPOINTS
The folloiwing endpoints are available in the PepperApp API:  
- **'/api/pepper/all'**	(GET) - Get all peppers in the database.
- **'/api/pepper/mild'** (GET) - Get all mild peppers from the database.
- **'/api/pepper/medium'** (GET) - Get all medium peppers from the database.
- **'/api/pepper/mediumhot'** (GET) - Get all medium-hot peppers from the database.
- **'/api/pepper/hot'** (GET) - Get all hot peppers from the database.
- **'/api/pepper/superhot'** (GET) - Get all super-hot peppers from the database.
- **'/api/pepper/{pepperName}'** (GET) - Get a single pepper from the database by name.
- **'/api/pepper'**	(POST) - Create a new pepper entry in the database.
- **'/api/pepper/{pepperName}'** (PUT) - Update a pepper entry from the database by name.
- **'/api/pepper/{pepperName}'** (DELETE) - Remove a pepper entry from the database by name.

### UNIT TESTS
To run the unit tests for PepperApp, follow these steps:
1. In the Test Explorer window, review a list of all available tests.
2. Click the "Run All" button to execute the tests.
3. Review the results of the tests.

The unit tests cover the following areas of the application:
-'PepperHeatClassTest': Validates the functionality of the AssignPepperHeatClass algorithm, which assigns the appropriate Heat Class to entries in the database.
-'PrintPepperToConsoleTest': Validates that the values of a PepperDTO are being printed to the console correctly.
-'IsInstanceOfTypeTest': Validates that objects added are of the expected type.

### FUTURE UPDATES
- Build a web applicaton that consumes the PepperApp API.
- Expand the database schema to include additional information about the peppers, such as their species, flavor profile or growing conditions.
- Implement additional search functionality to find peppers by other classifications.
- Add additional unit tests.
