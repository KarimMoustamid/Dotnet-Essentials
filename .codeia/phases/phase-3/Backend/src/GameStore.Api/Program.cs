using GameStore.Api.Data;
using GameStore.Api.Features.Games;
using GameStore.Api.Features.Genres;

// STEP 1: Create the WebApplication builder with default settings and command-line args.
var builder = WebApplication.CreateBuilder(args);

// STEP 2: Retrieve the connection string named "GameStore" from configuration (appsettings.json).
var connString = builder.Configuration.GetConnectionString("GameStore");

// STEP 3: Register the SQLite database context (GameStoreContext) for dependency injection.
builder.Services.AddSqlite<GameStoreContext>(connString);

// STEP 4: Build the application, finalizing the service collection and middleware pipeline.
var app = builder.Build();

// STEP 5: Map all game-related endpoints (CRUD operations) under the "/games" route group.
app.MapGames();

// STEP 6: Map all genre-related endpoints under the "/genres" route group.
app.MapGenres();

// STEP 7: Ensure the database and tables are created (initializes the database on startup).
app.InitializeDb();

// STEP 8: Start the application and begin listening for HTTP requests.
app.Run();
