# PIN Project
This is my college project using <i><b>ASP.NET Core Web API</b></i> as local server and <i><b>Blazor Web App</b></i> as an application user interface. Project is a web quiz with various categories, multiple difficulties and preformance overview.

## QuizAppAPI
 - [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
 - Handles API requests from UI app and responds with data
 - Private data (user data, played quizzes, etc.) is collected from local database to which UI doesnt have direct access
 - Public data (quiz questions) is provided from online API service with HTTP requests from this server
## QuizAppUI
 - [Blazor Web App](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
 - Provides user interface and good looks
 - Any data requiered for app is requested from API server
## App Diagram
![App Diagram](https://i.imgur.com/SWfg6hE.png)
## App Images
![Main Screen](https://i.imgur.com/LddTUqh.png)
![Quiz](https://i.imgur.com/IBTDk4q.png)
