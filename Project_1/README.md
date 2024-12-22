# Routine Tracker

https://dbdiagram.io/d/Routines-Tracker-6768782efc29fb2b3b1bbb89

App that lets you track the last time you did something

 "can have" = optional

Core features: 
- user can create/manage items
  - items have a name, description, and last_maintenance_date
  - items can have a next_maintenance_date
    - items can also have a maintenance_frequency that will auto-set next_maintenance_date for every x time period
- user can create/manage categories
  - items are uncategorized by default
  - items can have multiple categories