<h1>Task Manager 📝</h1>

<h2>Description:</h2>

This project was developed to improve unit testing practices.

It is an API for a task management system, featuring two main entities: Task and User, with data stored in a PostgreSQL database. The API implements CRUD (Create, Read, Update, Delete) operations, providing endpoints to manage tasks and users effectively.

The project emphasizes testing practices and was built using concepts such as TDD (Test-Driven Development), AAA (Arrange-Act-Assert), Stryker (mutation testing), Moq (mocking framework), fixtures, and in-memory databases to ensure reliability, maintainability, and robustness.

<h2>Project structure</h2>

The project is organized in a way that ensures clarity and scalability. Below is a summary of the main folders and files:

### src

- **`Controllers/`**: Responsible for managing HTTP requests and delegating actions to the corresponding services.  

- **`Services/`**: Contains the business logic, implementing CRUD methods and other operations related to tasks and users.  
- **`DTOs/`**: Defines data transfer objects used for communication between application layers.  
- **`Validators/`**: Contains the necessary validations to ensure that the provided data is consistent and valid before being processed.  
- **`Exceptions/`**: Defines custom exceptions and error handling for a clear and controlled response in case of failures.  
- **`Migrations/`**: Database migration files, managing changes to the schema structure.  
- **`Models/`**: Represents database entities, such as the Task and User models.  
- **`Data/`**: Contains database access configuration and defines the data context, using Entity Framework to facilitate persistence operations.  
- **`Extensions/`**: Contains extension methods used to abstract configurations from `Program.cs`, improving the modularity and readability of the application setup.

### test

- **`Validators/`**: Contains unit tests to ensure validation logic is working as expected. 

- **`Controllers/`**: Includes tests for API endpoints and controller behavior.  
- **`Services/`**: Contains tests for business logic and service layer methods.  
- **`Fixtures/`**: Provides reusable test data and configurations to streamline testing.

<h2>Installation:</h2>

To install the project, you can download it as a .zip file or clone it directly from GitHub.

### Download as .zip

1. Access the repository on GitHub: [TaskManager](https://github.com/YuriLopess/TaskManager)  
2. Click on "Code" and select "Download ZIP".  
3. Extract the ZIP file to your preferred directory.  

### Clone with Git  

1. Open the terminal.  

2. Navigate to the directory where you want to clone the repository.  

3. Run the following command:  

   ```sh
   git clone https://github.com/YuriLopess/TaskManager.git

<h2>Running the Project Locally:</h2> 

1. Clone the repository to your local machine.

2. Navigate to the project folder in the terminal.

3. Configure the connection to the PostgreSQL database in the `appsettings.json` file.

4. Run the database migrations with the following command:


   ```sh
   dotnet ef database update
5. Start the project with the:

    ```sh
    dotnet run
<h2>Contact:</h2>

If you have any questions or want to discuss about the project, please feel free to contact me via this email: **[costalopesyuri@gmail.com](mailto:costalopesyuri@gmail.com)**
