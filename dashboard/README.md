# Heel-Kawn Dashboard

This is a minimal ASP.NET Core web API for the Heel-Kawn project. It exposes endpoints to read the JSON state files for players, villages, professions, and events, and returns their contents as JSON.

## How to Run

1. Ensure you have the .NET 8.0 SDK or later installed.
2. In this folder, run:
   ```bash
   dotnet run
   ```
3. The API will be available at `http://localhost:5000` (or the port shown in the console).

## Endpoints
- `/api/players` - Returns all player data
- `/api/villages` - Returns all village data
- `/api/professions` - Returns all profession data
- `/api/events` - Returns all event history

You can use these endpoints to build a live dashboard or integrate with other tools.