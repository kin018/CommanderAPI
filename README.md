# CommanderAPI
REST API using ASP.NET Core 3.1 while employing MVC, Representational state transfer,
Repository Patterns, Dependency Injection, Entity Framework, Data Transfer Objects (DTOs), and AutoMapper
to provide 6 API endpoints that allows user Create, Read Update and Delete resources. 


**STEPS**
_GET/READ_
Create Domain Model (Command)
Build Repository Interface
Implement Repository Interface (Mock Reposiory)
Create Controller (CommandsController)
Create Get and Read API Endpoints
Dependency Injection

_ENTITY FRAMEWORK & DATABASE_
Set Up SQL Server App Login
Entityframework Packages and Toolset
Create Database Context (CommanderContext)
Connect using Database connection String
Register DB Context in Startup
Create/Cancel Migrations
Revist Command Model
Add Data Validation to Command Model
Create Migrations again and Run migrations against Database
Add Data to Database
Revisit DB Context in Repo

_DATA TRANSFER OBJECTS AND ENDPOINT CREATION_
AutoMapper Package & Startup Registration
Create 1st DTO
Create mapping Profile
Update ActionResults for DTO use

_PUT/PATCH/DELETE_
Update Repo for Creating Resources
Create a New DTO (for Creating)
Create 3rd API Endpoint to Create Resources
Use CreatedAtRoute to return 201 CreatedAtRoute
Add Annotations to DTO to avoid 500 Errors
Update Repository to Support Updates
Add a New DTO (for Updating)
Add API Endpoint for Updating (PUT Request)
Update AutoMapper Profile
Install PATCH packages
Update Startup
Update AutoMapper
Add API Endpoint for Updating (PATCH Request)
Add API Endpoint for Deleting (DELETE Request)
