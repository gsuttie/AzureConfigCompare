# AzureConfigCompare

## Overview

AzureConfigCompare is a C# project that compares two Azure Web Apps, returning all properties and comparing differences between them. The project includes unit tests to verify the functionality of the comparison code.

## Prerequisites

- .NET 5.0 SDK or later
- Azure subscription
- Azure Service Principal with appropriate permissions

## Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/gsuttie/AzureConfigCompare.git
   cd AzureConfigCompare
   ```

2. Create an `appsettings.json` file in the `AzureConfigCompare` directory with the following content:
   ```json
   {
     "Azure": {
       "ClientId": "<your-client-id>",
       "ClientSecret": "<your-client-secret>",
       "TenantId": "<your-tenant-id>",
       "SubscriptionId": "<your-subscription-id>",
       "ResourceGroupName": "<your-resource-group-name>"
     }
   }
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

## Usage

To compare two Azure Web Apps, run the following command:
```sh
dotnet run --project AzureConfigCompare <webAppName1> <webAppName2>
```

Replace `<webAppName1>` and `<webAppName2>` with the names of the Azure Web Apps you want to compare.

## Running Unit Tests

To run the unit tests, use the following command:
```sh
dotnet test
```

This will execute all the unit tests in the `AzureConfigCompare.Tests` project and display the test results.

## GitHub Actions

The project includes a GitHub Action to build and test the project automatically. The GitHub Action is defined in the `.github/workflows/dotnet.yml` file. It is triggered on every push and pull request to the `main` branch.

The GitHub Action performs the following steps:
1. Checks out the repository
2. Sets up .NET 5.0
3. Restores dependencies
4. Builds the project
5. Runs the unit tests

To view the status of the GitHub Action, navigate to the "Actions" tab in the GitHub repository.
