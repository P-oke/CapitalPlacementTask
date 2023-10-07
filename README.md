# CapitalPlacementTask

This repository contains a .NET 7 application developed using clean architecture principles and utilizing Azure Cosmos DB as a NoSQL database. Below you'll find important information on how to set up and run the application, including necessary configurations and dependencies.

## Technologies Used

- **.NET 6:** The application is built on the latest version of the .NET, providing modern features and performance improvements.
- **Clean Architecture:** The project follows the clean architecture principles, ensuring a separation of concerns and maintainability of the codebase.
- **Azure Cosmos DB:** A globally distributed, multi-model database service provided by Microsoft Azure, used as the NoSQL database for this project.
- **xUnit:** xUnit is used as the testing framework for writing and running unit tests in the project.

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Azure Cosmos DB Account](https://azure.microsoft.com/en-us/services/cosmos-db/) or [Azure Cosmos DB Emulator](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator)

## Installation and Setup

1. Clone the repository to your local machine:

   ```
   git clone <repository-url>
   ```

2. Open the solution in your preferred IDE (Visual Studio, Visual Studio Code, etc.).

3. Configure Azure Cosmos DB:
   - If you are using the Azure Cosmos DB Emulator locally, make sure it's installed and running on your machine. You can find the emulator installation instructions [here](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator).
   - Obtain the following details from your Azure Cosmos DB account or emulator: `EndpointUri`, `DatabaseName`, and `PrimaryKey`.
   - Add these details to the `appsettings.json` file under the `"CosmosDbSettings"` section:

   ```json
   "CosmosDbSettings": {
     "EndpointUri": "<Your-EndpointUri>",
     "DatabaseName": "<Your-DatabaseName>",
     "PrimaryKey": "<Your-PrimaryKey>"
   }
   ```

4. Build and run the application. The application will be accessible at the following URLs:
   - `https://localhost:7075`
   - `http://localhost:5068`

## Running Tests

Unit tests for this project are written using xUnit. To run the tests, use the following command in the terminal:

```bash
dotnet test
```

This will execute all the unit tests in the project and provide the test results.

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute the code as per the license terms.

---
