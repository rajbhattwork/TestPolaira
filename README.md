# Test3

A production-ready ASP.NET Core Web API scaffold.

## Tech Stack

- **Target:** API
- **App Name:** Test3
- **Backend:** ASP.NET Core Web API (C#)
- **Runtime:** .NET 10 (LTS)
- **OpenAPI:** Swashbuckle.AspNetCore 10.2.3
- **Logging:** Serilog 10.0.0
- **Testing:** xUnit

## Project Structure

```
Test3.slnx                          # Solution file
global.json                         # Pins SDK version (10.0.401)
.editorconfig                       # Code style rules
.config/dotnet-tools.json           # Local CLI tools (swagger)
scripts/
  build.sh                          # Build, test, publish helper
src/
  Test3.Api/
    Controllers/
      HealthController.cs           # GET /api/health
      WeatherForecastController.cs  # GET /api/weatherforecast
    Middleware/
      GlobalExceptionHandlerMiddleware.cs
    Models/
      WeatherForecast.cs
    Services/
      IWeatherService.cs
      WeatherService.cs
    Program.cs
    appsettings.json
    appsettings.Development.json
tests/
  Test3.Api.Tests/
    Services/
      WeatherServiceTests.cs
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Getting Started

```bash
# Restore packages
dotnet restore

# Run the API (development)
dotnet run --project src/Test3.Api

# Browse Swagger UI
# http://localhost:5000/swagger
```

## Building

```bash
# Build and test
./scripts/build.sh

# Build, test, and publish
./scripts/build.sh --publish
```

## Testing

```bash
dotnet test
```

## API Endpoints

| Method | Path                      | Description                     |
|--------|---------------------------|---------------------------------|
| GET    | /api/health               | Service liveness check          |
| GET    | /api/weatherforecast      | Weather forecasts (next N days) |
| GET    | /health                   | ASP.NET health check endpoint   |

Interactive docs available at `/swagger` when running.

## OpenAPI

The machine-readable API description lives at `.polaira/openapi.json` (build output, not committed).
Regenerate it from source:

```bash
./.polaira/emit-openapi.sh
```

## Vulnerability Audit

Run `dotnet list package --vulnerable --include-transitive` to check for known vulnerabilities.
Results at time of scaffold: **no vulnerabilities reported**.

## Configuration

| Key                          | Default     | Description               |
|------------------------------|-------------|---------------------------|
| Serilog:MinimumLevel:Default | Information | Log level (prod)          |
| AllowedHosts                 | *           | CORS allowed hosts        |

Override any setting via environment variables using the `__` separator,
e.g. `Serilog__MinimumLevel__Default=Debug`.
