# CurrencyExchangeRatesAPI

Description
Currency Exchange Rates API is a .NET Web API sample that provides currency exchange rates 
for the following currencies British Pound (GBP), Euro (EUR) United States Dollar (USD), and Peruvian Sol (PEN).

The solution follows the Clean Architecture design
 - Infrastructure: Manage external resources such as data stores. In this sample it will be just an In Memory DB.
 - ApplicationCore: Contains all the logic, validation, exceptions, and interfaces. This could be reused in case 
	we need to expose this API through a different protocol such as SOAP or gRPC 
 - WebApi: Exposes REST serivces to create, read, and update entities.

Some things that you will find in this sample are
 - ApplicationCore uses Command and Query services. Each use case is implemented in one file.
 - Validations and custom exceptions in the ApplicationCore layer
 - Global exception handling and custom http response codes and messages
 - API documentation using Swagger
 - Functional Tests
 - Unit Tests

Features

i. Features Implemented
 - Lists the currency exchange rates for a currency (GBP, EUR, USD, PEN).
 - Adds new currency exchange rate
 - Updates an existing currency exchange rate

ii. Nice to have
 - A different data store, would be nice to use a persistent databas such as PostgresSQL in Azure
 - Integration Tests, were left aside because I didn't see much value on them since I am using In Memory DB
   and I already have some Function Tests in place.
 - Security
 - A pipeline for deployment





