# Routine Tracker

by Jason Fox

## Project Requirements


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
- Users can create groups which allow shared access to items and categories
- NextDate for items will automatically update based on frequency
- Items can have inceased precision based on time of day instead of just date
- Frequency can have increased precision and support for multiple formats (ex. 1d, 12h, 4w)