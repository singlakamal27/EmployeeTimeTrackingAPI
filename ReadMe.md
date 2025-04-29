# Employee Time Tracking API
A minimal production style .NET 8 Web API for managing employees, locations, categories, and time tracking records.

# Features

- Employee CRUD (Create, Read, Update, Delete)
- Time tracking with:
  - Employee ID
  - Start/End time
  - Location
  - Work category
  - Notes
- Location and Category management
- API versioning (URL segment support)
- Swagger UI
- IQueryable for optmized performance when deployed to database.
- In-memory storage (e.g. switch to DB later)
- xUnit test cases for core endpoint

# Requirements

- .NET 8 SDK
- Optional: `curl`, Postman, or Swagger UI (http://localhost:5096/swagger)

# Run Locally
- git clone https://github.com/singlakamal27/EmployeeTimeTrackingAPI.git
- cd EmployeeTimeTrackingAPI
- dotnet build
- dotnet run

# Run Tests
- dotnet test

# Assumption
- Employee FirstName is required to create employee
- TimeTracking event must have either of StartTime or EndTime Set to successfully create a Time Record


 