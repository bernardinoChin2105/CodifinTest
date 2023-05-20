# Codifin
Technical test for Codifin position

This is a demo project powered by ASP.Net Core 3.1, EntityFramework, SQL Server DataBase and integration with [jsonplaceholder](https://jsonplaceholder.typicode.com) site for retrieving demonstration data.

## Stack & Important Packages
- Microsot .Net Core
- Microsoft Entity Framework core
- Microsoft Entity Framework core Sql Server
- Microsoft ASP Net Core Authentication Jwt Bearer
- RestSharp
- NewtonSoft Json

## Features
- GET api/posts (Get posts with filter and pagination options)
- GET api/posts/all (Get all posts)
- POST api/users (Register a new user)
- POST api/users/authenticate (Authenticate a user and get a JWT Token)
- POST api/posts/initialize-data (Retrieve posts from [jsonplaceholder](https://jsonplaceholder.typicode.com) and save them in the DataBase)
- POST api/comments/initialize-data (Retrieve comments from [jsonplaceholder](https://jsonplaceholder.typicode.com) and save them in the DataBase)
- GET api/users/refresh-token (Generate a new token once is expired)

- **Note:** You could import into Postman, the CODIFIN.postman_collection.json file included in the Setup folder and point the {{base-url}} 
- variable to your localhost server once you run the web application.

## Setup

### Required Steps
- Clone the github repository
- Restore nuget packages at solution level
- Build the solution

### Considerations
- The current project uses Entity Framework Core and was developed using Code First Approach. 
The database is created every time you start the application for testing purposes. You could need to change that aspect
commenting on the lines **_Context.Database.EnsureDeleted();** & **_Context.Database.EnsureCreated();**  in the startup.cs file
from the CodifinAPI project once you have created the database in the first project execution:

![](https://i.imgur.com/rEKDQYh.png)

One another option is to use [migration files](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli), 
for simplicity, the current project uses the previously mentioned methods.

## Unit & Integration Tests
The solution uses unit and integration tests included in the project APITests. 

![](https://i.imgur.com/U5XNFzk.png)

![](https://i.imgur.com/LjRRZgs.png)





