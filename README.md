# ProbabilityCalculator

The application allows users to enter two valid probability values and choose an operation of their preference.  
Based on the inputs, the app performs the calculation and returns the result in real time.

## Tech Stack

- ASP.NET Core MVC 8
- AutoMapper
- NUnit + 

## Setup Instructions

### 1. Clone the Repository
```bash
git https://github.com/kapilgm46/ProbabilityCalculator.git
cd ProbabilityCalculator
```

### 2. Restore NuGet Packages
```bash
dotnet restore
```
### 3. Build the Project

```bash
dotnet build
```

### 4. Run the API

```bash
dotnet run
```
The App will be available at:
https://localhost:44334/Calculator/Calculator

## Logging
A log file named App_logs.txt will be created in the project directory.

Each entry includes:
  - Date and time of the calculation
  - Type of calculation performed
  - Input probabilities
  - The resulting output
