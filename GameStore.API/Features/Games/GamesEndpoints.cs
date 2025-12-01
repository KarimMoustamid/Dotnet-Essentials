namespace GameStore.API.Features.Games
{
    using CreateGame;
    using DeleteGame;
    using GetGame;
    using GetGames;
    using UpdateGame;

    public static class GamesEndpoints
    {
        public static void MapGames(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "Hello World!");
            app.MapGetGames();
            app.MapGetGame();
            app.MapCreateGame();
            app.MapUpdateGame();
            app.MapDeleteGame();
        }
    }
}