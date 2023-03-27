**PepperApp** was created in 2023 as my capstone project for Code Kentucky's Software Development Course 2.
PepperApp was built using Visual Studio Community 2022 and .NET 7.0.
All instructions in this file are specific to running the project from Visual Studio.

### DESCRIPTION
PepperApp helps users manage information about hot peppers and their Scoville Heat Unit ratings, making it easy to recall, update and maintain this data.
The Scoville scale is a tool for measuring the spiciness or pungency of hot peppers.
The scale measures the amount of capsaicin in a pepper and assigns it a number rating in Scoville Heat Units (SHUs).
Hot pepper enthusiasts and hot sauce artisans may find PepperApp useful for storing and updating information about their favorite peppers or for discovering new varieties to try in their recipes.

### ARCHITECTURE
PepperApp consists of several modular and extensible layers that allow for flexibility and adaptability to different applications and use cases.
Entity Framework is employed to manage connections to a SQLite database in the Data layer.
The Entities layer defines the data structure that represents a pepper for the purposes of the project and includes some objects that are seeded into the database at creation.
Logic and validation are isolated in the Services layer while the Repository layer addresses data storage and retrieval.
The Data Transfer Objects (DTOs) decouple the data model from other layers by exposing only necessary values, providing a simplified view of the data required by end users and other classes in the projects.

By way of these abstractions, PepperApp is able to support multiple applications that interact with the same data in different ways:
- A console application that enables users to perform CRUD operations on the database based on input received from the console.
- A CRUD API with a Swagger UI that allows users to interact with the database through a web browser.

### FEATURES
The following items from the Project Requirements Feature List are implemented in PepperApp:

- **Create 3 or more unit tests for your application:** The PepperApp.Tests project contains the unit tests for PepperApp. 
PepperApp.Tests uses the MSTest framework.
The unit tests are contained in the PepperTest and PepperHeatClassTest files, which each inherit from the TestBase class.

- **Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program:** The Entities folder contains the defaultPeppers dictionary.
The defaultPeppers dictionary contains several common pepper varieties that are instantiated and seeded into the database at creation.
These entries are protected by the isReadOnly boolean to prevent their modification or removal from the database.

- **Implement a log that records errors, invalid inputs, or other important events and writes them to a text file:** Serilog is employed to log erroneous entries and important events to a text file.
The Logger folder contains the StartLogger method which sets up and starts the logging process and sets the log file path according to the operating system.

- **Make your application an API:** The PepperApp.API project contains the Startup and Program classes that generate the API.
SQLite, the PepperContext, and the services and repository layers are registered as services to enable interaction with the data.
Swagger UI is registered for development and testing purposes.

- **Make your application a CRUD API:** The PepperController class enables CRUD operations as API endpoints.
These endpoints depend on the Services layer to provide logic and validation and to make calls to the repository layer that interacts with the database.
The endpoints use the Request and Response DTOs to expose only the necessary data to the end user.

- **Make your application asynchronous:** Most methods in PepperApp and the applications that derive from it are written asynchronously.
This enables improved performance while freeing up system resources by allowing tasks to run in the background while the application continues to respond to user input.

- **Query your database using a raw SQL query, not EF:** All of the repository methods that return lists of the peppers sorted by Heat Class make raw SQL queries to return only the requested data from the database.

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
Users are given options to view, add, update or remove pepper entries; or to save a list of all of the peppers in the database to a text file.
The console application guides users through these functions and receives input to update the database accordingly.
When finished, users may terminate the application by selecting exit and pressing enter.

### API ENDPOINTS
The following endpoints are available in the PepperApp API:  
- **'/api/pepper/all'**  (GET)  
	Description: Get all peppers in the database.    		
- **'/api/pepper/mild'** (GET)  
	Description: Get all mild peppers from the database.  
- **'/api/pepper/medium'** (GET)  
	Description: Get all medium peppers from the database.  
- **'/api/pepper/mediumhot'** (GET)  
	Description: Get all medium-hot peppers from the database.
- **'/api/pepper/hot'** (GET)  
	Description: Get all hot peppers from the database.
- **'/api/pepper/superhot'** (GET)  
	Description: Get all super-hot peppers from the database.
- **'/api/pepper/{pepperName}'** (GET)  
	Description: Get a single pepper from the database by name.
- **'/api/pepper'**	(POST)  
	Description: Create a new pepper entry in the database.
- **'/api/pepper/{pepperName}'** (PUT)  
	Description: Update a pepper entry from the database by name.
- **'/api/pepper/{pepperName}'** (DELETE)  
	Description: Remove a pepper entry from the database by name.

Successful requests to these endpoints will return JSON objects with the following fields: "pepperName", "pepperScovilleUnitMinimum", "pepperScovilleUnitMaximum", "pepperHeatClass".
Invalid requests will return errors, such as when an entry is not found or when a user attempts to create a pepper with a duplicate name.
In case of an error, the system displays a message with details about the issue and logs the error in the application's log file.

**Example JSON POST request body:**  
{  
&nbsp; &nbsp; "pepperName": "SomePepper",  
&nbsp; &nbsp; "pepperScovilleUnitMinimum": 100000,  
&nbsp; &nbsp; "pepperScovilleUnitMaximum": 350000  
}

**Example JSON GET response body:**  
{  
&nbsp; &nbsp; "pepperName": "SomePepper",  
&nbsp; &nbsp; "pepperScovilleUnitMinimum": 100000,  
&nbsp; &nbsp; "pepperScovilleUnitMaximum": 350000,  
&nbsp; &nbsp; "pepperHeatClass": "hot"  
}  

### UNIT TESTS
To run the unit tests for PepperApp, follow these steps:
1. In the Test Explorer window, review the list of available tests.
2. Click the "Run All" button to execute the tests.
3. Review the results of the tests.

The unit tests cover the following areas of the application:
- **'PepperHeatClassTest':** Validates the functionality of the AssignPepperHeatClass algorithm, which assigns the appropriate Heat Class to entries in the database.
- **'PrintPepperToConsoleTest':** Validates that the values of a PepperDto are being printed to the console correctly.
- **'IsInstanceOfTypeTest':** Validates that objects added are of the expected type.

### FUTURE UPDATES
- Build a web application that consumes the PepperApp API.
- Expand the database schema to include additional information about the peppers, such as their species, flavor profile or growing conditions.
- Implement additional search functionality to find peppers by other classifications.
- Add additional unit tests.
