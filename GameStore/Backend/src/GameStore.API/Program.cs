// ============================================================
// Program.cs — Application Entry Point
// Step 1: Building the Phase 1 REST API
// Role: Configures services, maps endpoints, initializes DB, and runs the app.
// Key design decision: Uses Minimal API pattern with extension methods
// (MapGames, MapGenres) so that endpoint routes live in feature folders,
// not in this file. This keeps Program.cs focused on infrastructure setup
// and avoids a monolithic endpoint file.
// ============================================================

// WebApplication.CreateBuilder initializes the Minimal API host with
// default configuration, logging, and DI container.
var builder = WebApplication.CreateBuilder(args);

// Load JSONC configuration files
builder.Configuration
    .AddJsonFile("appsettings.jsonc", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.jsonc", optional: true, reloadOnChange: true);

// Read the connection string named "GameStore" from app settings
// (appsettings.json or environment variables).
var connString = builder.Configuration.GetConnectionString("GameStore");

// Register the Sqlite-backed GameStoreContext as a scoped service.
// AddSqlite<TContext> is a custom extension that calls
// builder.Services.AddDbContext<TContext> with options.UseSqlite(connString).
// Scoped lifetime means one context instance per HTTP request.
//builder.Services.AddSqlite<GameStoreContext>(connString); TODO: // Registers SQLite-backed DbContext; EF Core manages connection pooling 

// Build the WebApplication — finalizes service registration and configures
// the middleware pipeline. After this, services cannot be modified.
var app = builder.Build();

// MapGames() and MapGenres() are extension methods defined in the
// Games and Genres feature folders. Each internally calls app.MapGet(),
// app.MapPost(), app.MapPut(), app.MapDelete() to register REST endpoints.
// Factoring out mapping into feature modules improves maintainability
// and prepares for future phase additions like validation or auth.
//app.MapGames(); TODO: // Maps all /games endpoints — DTOs ensure API contract is independent of Game entity shape
//app.MapGenres(); TODO: // Maps all /genres endpoints — same decoupling principle

// InitializeDb() creates the database and applies pending migrations
// (or creates tables if they don't exist). Calls EnsureCreated() or
// the Migrate() method on the GameStoreContext.
// Called after mapping to ensure database is ready before first request.
//app.InitializeDb(); TODO: // Applies pending migrations or seeds initial data if DB is empty

// Start the HTTP server and begin processing incoming requests.
// Blocking call — runs until the process is terminated.
app.Run();
