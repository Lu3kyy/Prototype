# Rock, Paper, Scissors, Lizard, Spock Game API

A clean, lightweight ASP.NET Core Web API for playing the Rock, Paper, Scissors, Lizard, Spock game.

## Project Cleanup

This project has been stripped of all unnecessary dependencies and files:
- ✅ Removed Entity Framework and database packages
- ✅ Removed Student model and StudentsController
- ✅ Removed AppDbContext and Data folder
- ✅ Removed all database artifacts (student.db)
- ✅ Fixed all namespaces to use `myapiP` consistently
- ✅ Clean configuration files ready for Azure deployment

## Architecture

- **Controller**: `GameController.cs` - Handles game logic via `/api/game/play` endpoint
- **Service**: `GameService.cs` - Game rules and outcome determination
- **Models**: Game-related DTOs (GameMove, GameResult, GameMoveRequest)
- **Dependencies**: Only ASP.NET Core, Swagger/OpenAPI

## API Endpoints

### Health Check
```
GET /api/game/health
```
Returns: `{ "status": "healthy", "timestamp": "2025-01-22T..." }`

### Play Game
```
POST /api/game/play
Content-Type: application/json

{
  "move": "rock"  // or: paper, scissors, lizard, spock
}
```

Returns:
```json
{
  "playerMove": "Rock",
  "cpuMove": "Scissors",
  "outcome": "Win",
  "message": "Rock crushes Scissors - You Win!"
}
```

## Running Locally

```bash
# Restore dependencies
dotnet restore

# Run the API
dotnet run

# Access Swagger UI
# https://localhost:7000/swagger
```

## Azure Deployment

This project is optimized for Azure deployment:
- Health check endpoint for App Service monitoring
- Application Insights integration configured
- CORS enabled for cross-origin requests
- Lightweight, stateless design for scalability

### Deploy to Azure App Service

```bash
# Publish the application
dotnet publish -c Release

# Deploy using Azure CLI
az webapp up --name <app-name> --resource-group <resource-group>
```

## Project Structure

```
Controllers/
  └── GameController.cs          # Game endpoints
Models/
  ├── GameMove.cs                # Enum for game moves
  ├── GameResult.cs              # Response model
  └── GameMoveRequest.cs         # Request model
Services/
  └── GameService.cs             # Game business logic
Program.cs                        # DI & middleware configuration
appsettings.json                  # Production settings
appsettings.Development.json      # Development settings
```

## Clean State

This project contains **only what's needed** for the game API:
- No database dependencies
- No Entity Framework
- No unused controllers or models
- No build artifacts in source control

All cleanup is complete and ready for production deployment.


