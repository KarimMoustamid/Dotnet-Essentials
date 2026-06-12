// STEP 1: Create the web application builder to configure services and the HTTP pipeline.
using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// STEP 2: Add Razor Components services – enables Blazor server-side rendering.
builder.Services.AddRazorComponents();

// STEP 3: Retrieve the backend API URL from configuration (appsettings.json).
// Throw an exception if it is missing to fail fast.
var backendApiUrl = builder.Configuration["BackendApiUrl"] ??
    throw new Exception("BackendApiUrl is not set");

// STEP 4: Register a typed HttpClient for GamesClient with the backend base address.
// ⚠ Forward-ref: GamesClient is defined in the Clients folder (Phase 5) and uses this HttpClient to call the API.
builder.Services.AddHttpClient<GamesClient>(
    client => client.BaseAddress = new Uri(backendApiUrl));

// STEP 5: Register a typed HttpClient for GenresClient similarly.
// ⚠ Forward-ref: GenresClient is also defined in the Clients folder.
builder.Services.AddHttpClient<GenresClient>(
    client => client.BaseAddress = new Uri(backendApiUrl));

// STEP 6: Build the application.
var app = builder.Build();

// STEP 7: Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // In development, enable WebAssembly debugging for Blazor WebAssembly.
    app.UseWebAssemblyDebugging();
}
else
{
    // In production, use a custom exception handler and HSTS.
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// STEP 8: Enable static files (e.g., wwwroot content) and antiforgery token validation.
app.UseStaticFiles();
app.UseAntiforgery();

// STEP 9: Map the root App component to handle all HTTP requests.
// All Razor component pages are rendered through this pipeline.
app.MapRazorComponents<App>();

// STEP 10: Start the web server.
app.Run();
