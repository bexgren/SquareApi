# Squares

A web application for generating different colored squares based on predefined rules.

## Screenshots

If no images are visible - go to README.md in squares

### Start view

![Start view](screenshots/nosquare.png)

### Functionality

![One square](screenshots/onesquare.png)
![Two squares](screenshots/twosquares.png)
![Three squares](screenshots/threesquares.png)

## About the project

SquareApi is a small application where users can generate colorful squares according to specific rules. The project was created as an assignment for a possible internship but later used as a learning possibility about C#/.NET.

## Features

- Generate colorful squares
  - Each square with a different color
- Display generated results in a visual grid
  - The visual placement is a predefined pattern

## What I learned

- Exploring C#/.NET for the first time
- Working with JSON
- Connecting frontend functionality with application logic

## Technologies

- React
- JavaScript
- C#/.NET
- Tailwind
- JSON
- Vite

## Assigment

Create a website that generates a new square with a new color each time you press the button. The squares will place themself in a squarepattern.

- ### Frontend
  #### React.js
  The application is able to render squares dynamically on the page
- ### Backend
  #### .NET/C#
  Managing state (store and get data from a _JSON-file_)

## Getting Started

### Installation

#### Prerequisites

Make sure the following is installed before you start:

- Node.js (version 18.0.0 or later)
- Git
- A modern browser (Chrome, Firefox)
- .NET

Make sure you have a certificate for .NET on your computer (powershell-terminal):

```bash
dotnet dev-certs https
dotnet dev-certs https --trust
```

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

## Folder Structure

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
