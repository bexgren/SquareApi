# SquareApi

## Overview

A coding-assignment for Wizardworks.

### The Assignment

Create a website that generates a new square with a new color each time you press the button. The squares will place themself in a squarepattern.

- ### Frontend
  #### React.js
  The application is able to render squares dynamically on the page
- ### Backend
  #### .NET/C#
  Managing state (store and get data from a _JSON-file_)

## Installation and Setup

### Prerequisites

Make sure the following is installed before you start:

- Node.js (version 18.0.0 or later)
- Git
- A modern browser (Chrome, Firefox)
- .NET

### Run .NET application

```bash
dotnet run
```

The application is listening on

https://localhost:7059 and http://localhost:5051

#### Hosting environment:

Development

#### Shut down application

Press Ctrl+C

#### CORS Policy Origin

Already gives this link access to the API:
http://localhost:5173

- The localhost-link for the React-application
- **If yours is a different link**:
  - Change the **Cors Policy** link in Program.cs

### Run React-application

- Navigate to the squares-folder in a **new** terminal
  ```bash
  cd squares
  ```
- Run project
  ```bash
  npm run dev
  ```

## Folder Structure and Technologies

The project uses **C#/.NET** with **JSON**-file and **React** for frontend

```plaintext
SquareApi/
| - Controllers/  # the controller-file
| - docs/         # Documentation-files
| - Models/       # the model-file
| - Properties/
|  | - launchSettings.json # The launch-adress etc
| - Services/     # Service-files
|  | - JsonFileHelper.cs
|  | - SquareService.cs
| - squares/      # React-project
| - Program.cs    # The application-settings
| - squares.json  # JSON-file (database)
```
