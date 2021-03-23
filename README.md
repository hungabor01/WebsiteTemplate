# Website template

## Introduction
This is a template for an ASP.Net Core MVC website. It uses the MVC architecture, so the frontend only consists of html, css and pure javascript. This code skeleton is a good starting point for a more complex webapp, since it uses the principles of the clean architecture. The most common features are added, like database connection, basic identity service, Azure support or unit tests.

## Versions
- ASP.Net Core MVC net5.0
- SQL Server 2017
- Entity Framework Core 5
- bootstrap 4.6.0
- xUnit 2.4.1
- Moq 4.16.1

## Getting started
- Install net5.0 sdk and a compatible Visual Studio version.
- Install SQL Server.
- Open the solution in Visual Studio and apply the migrations.
- Check the connection string and the Application Insights instrumentation key in appsettings.json.
- Check the Azure keyvault url in Program.cs.
- Run the website.

## Overall architecture
The code is built upon the onion layered clean architecture design. Therefore, all project references point towards the BusinessLogic (domain, application) layer. This central project contains the ControllerManager classes, which are supposed to perform the controller's actions, the HostedService background jobs, the domain models and the interfaces for the other projects to achieve dependency inversion. There are two projects for the database access. The Database project has the Entity Framework related components and the Repository, Unit of Work pattern components. The DatabaseAccess project uses those building blocks to execute the tasks requested by the BusinessLogic. Its public API implements the the interfaces defined in the BusinessLogic and maps the data between the ViewModels and the Entities. There is a separate project for the services, which usually are the background services for the HostedServices and other simple services like email sending. The website project only contains the controllers and the UI. The controllers call the ControllerManagers in the BusinessLogic, so they should not have too much code. The UI is separated to the cshtml Views and to the static files, like css, js or images. Also a unit test project belongs to each project. Basic helper classes are added to the unit tests.

## Features
- [dependency injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0)
The code uses the built-in DI container and constructor injection. The dependencies are registered in their own project's StartupExtensions class. These extension methods are called in the Startup class along with the general dependencies.
- Azure keyvault
- Application Insights
- Blob file logging in Azure
- [toaster notifications](https://github.com/nabinked/NToastNotify)
- [seo optimalization](https://github.com/vitali-karmanov/ASPNET-Core-SEO-Template)
- cookie, privacy policy, gdpr
- hsts, https redirection
- robots.txt and sitemap endpoint
- url rewriting to use dashes between words and non capital letters
- custom error page for unhandled errors and errors with status code
- font-awesome 5.15.2 with cdn
- twitter-bootstrap 4.6.0 with cdn
- bundle and image minification
- full html head meta
- live recompiling of cshtml files in development
- launch settings and release profile (excluded from the public repo)
- guards for throwing exception if an object is null
- basic Identity authentication and authorization
- EF Core code first approach
- Repository and Unit of Work patterns
- migrations for identity tables
- xUnit attribute for skipping integration tests
- helper classes for unit tests (configuration, database, identity)
