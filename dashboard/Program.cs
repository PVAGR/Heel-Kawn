using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

string configPath = Path.Combine("..", "mod", "src");
string GetFile(string name) => Path.Combine(configPath, name);
string adminToken = Environment.GetEnvironmentVariable("HEELKAWN_DASHBOARD_TOKEN") ?? "changeme";

bool IsAuthorized(HttpContext ctx)
{
    var token = ctx.Request.Headers["X-Admin-Token"].ToString();
    return token == adminToken;
}

app.MapGet("/api/players", () =>
{
    var file = GetFile("heelkawn_players.json");
    return File.Exists(file) ? Results.Content(File.ReadAllText(file), "application/json") : Results.NotFound();
});

app.MapGet("/api/villages", () =>
{
    var file = GetFile("heelkawn_villages.json");
    return File.Exists(file) ? Results.Content(File.ReadAllText(file), "application/json") : Results.NotFound();
});

app.MapGet("/api/professions", () =>
{
    var file = GetFile("heelkawn_professions.json");
    return File.Exists(file) ? Results.Content(File.ReadAllText(file), "application/json") : Results.NotFound();
});

app.MapGet("/api/events", () =>
{
    var file = GetFile("heelkawn_events.json");
    return File.Exists(file) ? Results.Content(File.ReadAllText(file), "application/json") : Results.NotFound();
});

// Example admin endpoint (protected)
app.MapPost("/api/admin/announce", (HttpContext ctx, string message) =>
{
    if (!IsAuthorized(ctx)) return Results.Unauthorized();
    // TODO: Broadcast announcement to mod (extend as needed)
    return Results.Ok($"Announcement sent: {message}");
});

app.Run();