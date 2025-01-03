# Entity Framework Core

- What is an ORM? What's the purpose of it?
	- Object Relational Mapper allows interacting with relational databases using OOP such as C# and EF
- What is DbContext class in EF Core?
	- Represents a session with a database and provdes an API for communicating with the database
- What are 2 ways of connecting your DB to code?
		- Code first and database first
	- When would you use which?
		- Use code first when you want to code purely in OOP language
		- Use db first (scaffolding) when you want to create your database directly in SQL
- What is migration?
	- Versioned schemas of the database that allows tracking db schema changes over time
- What is DbSet?
	- Represents a collection of entities of a specific type within a DbContext
	- Acts as virtual representation of a db table
- What does OnModelCreating method do?
	- Allows customized mapping between entity classes and db schema 
		- Define details like table names, columns, relationships, and constraints
- How do you add/update/delete/query data from DB using ef core?
	Use db context with the table name, perform the CRUD action, and perform SaveChanges
- How do you "join" tables when querying your data in EF Core?
	- Use Join LINQ method within the query, specifying tables to join and common columns using lambda
- what does savechanges method do?
	- Commits db changes to the database server to be persister