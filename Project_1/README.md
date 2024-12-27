# Routine Tracker

by Jason Fox

## Description

C# ASP.NET API where users can create, manage, and categorize routine items to help organize their daily life.

## Project Requirements
- README that describes the application and its functionalities
- ERD of your DB
- The application should be ASP.NET Core application
- The application should build and run
- The application should have unit tests and at least 20% coverage (at least 5 unit tests that tests 5 different methods/functionality of your code)
- The application should communicate via HTTP(s) (Must have POST, GET, DELETE)
- The application should be RESTful API
- The application should persist data to a SQL Server DB
- The application should communicate to DB via EF Core (Entity Framework Core)


## Tech Stack
- C# 
- ASP.NET Core
- SQL Server (locally hosted)
- XUnit for testing

## Tables
[![ERD](./Assets/ERD.png)](https://dbdiagram.io/d/Routines-Tracker-6768782efc29fb2b3b1bbb89
)

## MVP Goals
- Users can be created
- Users can create and manage routine items
- Users can set a name and description for routine items
- Users can set a last and next observed date for items
- Users can create and manage categories (items are uncategorized by default)
- Users can assign and unassign items to a category

## Stretch Goals
- User passwords are hashed for security and integrity
- Hashed password is not returned in API calls
- Users can create groups which allow shared access to items and categories
- NextDate for items will automatically update based on frequency
- Items can have inceased precision based on time of day instead of just date
- Frequency can have increased precision and support for multiple formats (ex. 1d, 12h, 4w)