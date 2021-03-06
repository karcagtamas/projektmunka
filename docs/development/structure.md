# Project structure

- `.` - Docker(-compose) related files, solution, basic configurations, scripts
- `./MeetHut.Backend` - AspNetCore main application
  - `./ClientApp` - Angular frontend app
  - `./Configurations` - Web API configurations
  - `./Controllers` - ASP controllers
  - `./Middlewares` - Server level middlewares
  - `./Scripts` - MYSQL dump scripts
- `./MeetHut.CommonTools` - Common functions
- `./MeetHut.DataAccess` - Database layer (EntityFramework)
  - `./Entities` - EF Entity classes
  - `./Enums` - EF Enum definitions
  - `./Migrations` - EF generated migrations, use helper command to generate
  - `./Repositories` - EF repository class
- `./MeetHut.Services` - Services, Models
  - `./Application` - Application (Auth, User, ...) services, model definitions, mappers
  - `./Configurations` - Login configurations
  - `./Meet` - Meet (Room, Conference, ...) services, model definitions, mappers
- `./docs`
  - Documentation - Docsify

# Architecture

![Architecture](architecture.png)

Currently supporting horizontal scaling of the `Meethut.Backend` is out of scope. It should mostly work (the api is stateless), but features like Chat can be broken.
