var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Phase 1 only defines the domain model; later phases wire up endpoints and data access.
app.Run();
