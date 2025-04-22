# Excel Report Generation and Saving

This project demonstrates how to generate an Excel report from a database and save it as an `.xlsx` file using [ClosedXML](https://github.com/ClosedXML/ClosedXML) in an ASP.NET Core application. The report is populated with data fetched from a SQL database.

## Features

- Fetches data asynchronously from a database (`ReportItems`).
- Generates an Excel report with headers and data.
- Saves the Excel file to a specified folder on the server.
- Creates a new folder if it doesn't exist to store reports.
- Dynamically names the report file based on the current timestamp.

## Requirements

- .NET 8 or later
- [ClosedXML](https://github.com/ClosedXML/ClosedXML) library for working with Excel files
- A configured database context (e.g., Entity Framework Core)

## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/ajeetnpandey/GenerateReports.git
