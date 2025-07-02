PadelBookingAPI

Ett REST-API för bokning av padelbanor med tre banor. Systemet är byggt i .NET 8 med Entity Framework, Repository Pattern, Swagger, Postman och xUnit för tester.

Funktioner

CRUD för kunder och bokningar
Validering av bokningar (tider, dubbelbokning, öppettider)
Se bokningar för en viss dag
Se tillgängliga tider för ett datum
Räkna antal bokningar mellan två datum

- ASP.NET Core Web API
- Entity Framework Core
- Repository Pattern
- Swagger
- Postman
- xUnit

Testade User Stories

- Som kund kan jag se lediga tider
- Som kund kan jag boka en bana i en timme
- Som admin kan jag se bokningar en viss dag
- Som admin kan se antal bokningar mellan datum
- Systemet tillåter bara hela timmar
- Systemet tillåter bara bokning mellan 07–22
- Dubbelbokning är inte tillåten

Testning

- Enhetstester finns i testprojektet med xUnit
- API-testning är gjort i Postman och sparad i samling
