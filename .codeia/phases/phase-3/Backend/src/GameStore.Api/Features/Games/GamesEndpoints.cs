using GameStore.Api.Data;
using GameStore.Api.Features.Games.CreateGame;
using GameStore.Api.Features.Games.DeleteGame;
using GameStore.Api.Features.Games.GetGame;
using GameStore.Api.Features.Games.GetGames;
using GameStore.Api.Features.Games.UpdateGame;
using GameStore.Api.Models;

namespace GameStore.Api.Features.Games;

public static class GamesEndpoints
{
    // STEP 1: Define an extension method to group all game endpoints under a common prefix.
    public static void MapGames(this IEndpointRouteBuilder app)
    {
        // STEP 2: Create a route group with the prefix "/games" (e.g., POST /games, GET /games).
        var group = app.MapGroup("/games");

        // STEP 3: Map each specific game endpoint inside the group.
        group.MapGetGames();
        group.MapGetGame();
        group.MapCreateGame();
        group.MapUpdateGame();
        group.MapDeleteGame();
    }
}
