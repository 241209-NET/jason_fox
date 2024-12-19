# SQL Questions
These questions are here to help you engage with the material. We will use these questions to review and to prepare for QC. 
Define following terms and answer the questions in your own words, using any resources.

### DB terms
- Relational database
- SQL
- SQL Sublanguages:
	- DDL: Data Definition Language
		- Used to define and modify database structure
		- CREATE, ALTER, DROP, TRUNCATE
		- Ex: `CREATE TABLE users (id INT, name VARCHAR(50))`
	- DML: Data Manipulation Language
		- Used to manipulate data within the database
		- INSERT, UPDATE, DELETE, SELECT
		- Ex: `INSERT INTO users (id, name) VALUES (1, 'John')`
	- DQL: Data Query Language
		- Used to query for data within the database
		- SELECT 
		- `SELECT name FROM users WHERE id = 1`
	- DCL: Data Control Language
		- Used to control access to the database
		- GRANT, REVOKE
		- `GRANT SELECT ON users TO analyst_role`
	- TCL: Transaction Control Language
		- Transactions, commit, savepoints, rollbacks
		- Transactions are a bundle of SQL commands where all or none of them run
- Primary Key
	- Column or set of columns that uniquely identifies each row
	- Must be unique and not null
- Foreign Key
	- Column that references a primary key in another table
- Candidate Key
	- Set of columns in relational database that can uniquely identify each row in a table
	- Can be single or a combination of attributes
- Composite Key
	- Combination of two or more columns in a table that uniquely identifies each row
	- Is a specific type of candidate key
	- Always consists multiple attributes
- Tell me about normalization
		- Normalization aims to minimize redundancy and prevent inconsistencies by organizing data into tables & establishing relationships between them
    - 1NF
		- Basic tidying up
		- Each column contains indivisible values
		- No repeating groups
		- Each record is unique
	- 2NF
		- Organizing items by category
		- Must be in 1NF first
		- Remove partial dependencies
		- Every non-key column depends on the entire primary key
	- 3NF
		- Removing items that truly don't belong
		- Must be in 2NF first
		- Remove transitive dependencies
		- No non-key columns should depend on other non-key columns
- Referential Integrity
	- Ensures relationships between tables remain consistent
	- Enforced through foreign keys with rules
	- Ex: Can't add an oOder with a customer_id that doesn't exist in the Customers table
- Which keyword do I use to...
    - Create new table
		- CREATE TABLE
    - create a new record in a table
		- INSERT INTO
    - modify table structure
		- ALTER TABLE
    - delete table
		- DROP TABLE
    - modify existing row in a table
		- UPDATE table SET
    - delete a row
		- DELETE FROM
    - drop all rows in a table w/o deleting the table
		- TRUNCATE TABLE
- What are some SQL dialects/vendors we have?
		- MySQL, PostgreSQL, Oracle DB, SQLite, MSSQL
    - which one do we use?
		- MSSQL
- What are constraints?
		- Rules applied to data within a table to ensure data integrity
		- Basically data validation
    - Give me some examples and what they do
		- PRIMARY KEY, FOREIGN KEY, UNIQUE, NOT NULL, CHECK
- Tell me about some common SQL data types
	- DATETIME, VARCHAR, BOOL, INT, FLOAT, DOUBLE
- tell me about multiplicity and some examples
	- Quantitative relationship between entities
	- Ex: One-to-One, One-to-Many, Many-to-Many
- tell me about identity keyword
	- Used to automatically generate sequential values for each row in a table
- What is ERD?
	- Entity relationship diagram to map out a database in a visual manner

### Select statement
- Which Sublanguage is SELECT statement part of?
	- DQL
- Describe what each of the clause does
	- SELECT
		- Selects data from a database
	- FROM
		- Specifies which table to select or delete data from
	- WHERE
		- Filters a result set to only include records that match a condition
	- GROUP BY
		- Groups result set, used with aggregate functions
	- HAVING
		- Used instead of WHERE with aggregate functions
	- ORDER BY
		- Sorts a result set by a column in ascending or descending order
- how do I only get non-duplicate values? 
	- DISTINCT
- How do I limit the result to a certain number? 
	- TOP(x)
### Joins/Set Ops/Subqueries
- Joins
    - Inner Join
		- Returns rows that have matching values in both tables
    - Left join
		- Returns all rows from the left table (FROM) and matching rows from the right table (JOIN table ON)
		- Result is null from right if no match
    - Right join
		- Inverse of left join
    - Full join
		- Returns all rows when there is a match in either left or right table
    - What other joins did you find?
		- Cross join to view all possible combinations of something
- Set Operation
    - Union
		- Combines the result set of two or more SELECT statements (only distinct values)
    - Union all
		- Like union but allows duplicates
    - Intersect
		- Compares results of two SELECT queries and returns only the rows common to both
    - Except
		- Used to filter records based on the intersection of records, inverse of intersect
- What is the difference between set operation and join?
	- Join combines rows from multiple columns based on a shared column
	- Set operation combines result sets from multiple select statements without relying on relationships
- Subquery
    - what is it?
		- Query within another SQL statement
		- Allows using result of one query as input for another
    - in which clauses can you use subquery?
		- SELECT, FROM, WHERE

### Functions/Stored Procedures/Triggers/Cascades/Views/Index/Transactions
- What are functions?
			- Pre-written code that performs a specific operation on data
			- Accepts input parameters
    - What are Aggregate functions?
			- Performs a calculation on a set of values and returns a value
        - What are some examples of aggregate functions?
			- MIN, MAX, COUNT, SUM, AVG
    - How about Scalar functions?
			- User defined functions that return a single value for each row in a result set
        - some examples of scalar functions?
			- LENGTH, UPPER, LOWER, ROUND, NOW, SUBSTRING, etc
	- There are three different types of functions. What are they?
			- Scalar, Aggregate, Window
- What are stored procedures?
			- Prepared SQL code that can be reused
	- What's the difference between functions and stored procedures? When would you use which?
			- Stored procedures return a result set
	- What can stored procedures do that functions can't?
			- Stored procedures can execute multiple operations and modify data
	- How do you write stored procedures?
			- `CREATE PROCEDURE procedure_name AS <sql> GO;`
- What is index?
	- What's the difference between clustered and non-clustered index?
	- What are some best practices on using index?
- What is trigger?
	- Tell me about different types of triggers
	- How do you write triggers?
	- When would you want to use trigger?
- What is cascading? 
	- Different types of cascades?
	- What are best practices with cascades?
- What is view?
	- How do you make views?
	- When do you want to use views?
- What is transaction?
	- Describe the 4 properties of transaction (ACID)
	- What are isolation levels in transaction? What phenomena do we allow/not allow based on its level?
		- What's the default for SQL Server?