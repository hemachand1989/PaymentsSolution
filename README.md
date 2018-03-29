# PaymentsSolution
Demonstrates simple web app using .net core  and angular 4+ with backend as .net core webApi
# FrontEnd
1. Angular 4+ to create the font End.
2. Configuration of application is through .NET Core .
3. Execute command "dotnet run" at Payment.WebApp level to host the application on http://localhost:5000
# BackEnd
1. Configured .netCore WebApis as backend.
2. Used inbuilt .net core DI to inject services and repositories and loggers
3. Used serilogger extension to log key user activities at .netcore level and application level
4. Used repository pattern with EF code first approach to store and fetch payment details.
5. Execute command "dotnet run" at Payment.Services level to host the application on http://localhost:5001
6. Add your desired sql server path at appsettings.json.
# UnitTest
1. Used Xunit and Moq framework to write test cases
2. Implemented testcases for paymentService only.
#Yet to Implement
1. Security layer to WEBAPI using oauth2.0 standard preferrably JWT Tokens.

