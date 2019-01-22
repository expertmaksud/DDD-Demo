# DDD-Demo

This is an Asp.Net Core(2.2) Web Api based REST API solution. I architect the application following Multi-tier Domain Driven Design it provides a SOLID model to the application, I use Repository pattern, Generic repository, IoC, 
EF code first, Automapper, Dtos etc, utilizing patterns and best practices such as for unit testing and loosely couple always 
Implement interface.

Domain project contain the entities and aggregator.
Data project is responsible for database related operation, Generic repository implmentation, contain migration and DBContext.
Application project contain all Application related business Services.
API project create api using Asp.Net Web Api controller.

## Run Application:
To run the application Please update connection string from PX.Data/appsettings.json it is use for migration, also update 
Px.Api/appsettings.json to run the API.

## API End Points:

Currently implement the following sample api end points

```
GET api/books //Return all books
GET api/books/guid // return single book
POST api/books //add new book
PUT api/books/guid (requires data) //For update book
DELETE api/books/guid //For delete a book(SoftDelete just update IsDeleted field)
```

