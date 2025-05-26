# API - documentation

## Overview

This API serves to handle values for the squares in the application.

The calls which returns data does so in JSON-format.

### API/React - Flow

1. A default square is in the database
2. Start of the application
   - GET all squares
   - The default square is not showing on the page
3. Add new square
   - Replaces the default square with the new square
   - This square shows up on the page as the first square
   - All squares from this point on is visible on the page
4. Add another new square
   - Adds a new square to database in a new slot and shows it on the page

## Endpoints

### GET all squares

**GET**`/api/square`

- Returns a list of all squares in the database

**Example of return:**

```json
[
  {
    "id": 1,
    "color": "rgb(143,123,123)",
    "x": 1,
    "y": 1
  },
  {
    "id": 2,
    "color": "rgb(153,123,123)",
    "x": 2,
    "y": 2
  }
]
```

### Save the FIRST new square

**PUT**`/api/square/0`

- Saves and replaces the previous square in that slot in the database with the new square and returns the square as confirmation.

**Example of body as request and return:**

```json
{
  "id": 1,
  "color": "rgb(143,123,123)",
  "x": 1,
  "y": 1
}
```

### Save new square

**POST**`/api/square`

- Saves new square to new slot in the database and returns the square as confirmation

**Example of body as request and return:**

```json
{
  "id": 2,
  "color": "rgb(153,123,123)",
  "x": 2,
  "y": 2
}
```
