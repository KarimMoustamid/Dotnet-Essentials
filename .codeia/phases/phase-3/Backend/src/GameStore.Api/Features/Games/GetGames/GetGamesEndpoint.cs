using System;
using GameStore.Api.Data;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Features.Games.GetGames;

public static class GetGamesEndpoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app)
    {
        // GET /games
        // STEP 1: Map the GET request to the root of the group.
        app.MapGet("/", (GameStoreContext dbContext) => 
            // STEP 2: Query the Games table, eagerly load the Genre navigation property.
            dbContext.Games
                     .Include(game => game.Genre)
                     // STEP 3: Project each game to a GameSummaryDto, extracting the genre's name.
                     .Select(game => new GameSummaryDto(
                        game.Id,
                        game.Name,
                        game.Genre!.Name,   // ⚠ Forward-ref: Genre is a navigation property on the Game model (defined elsewhere)
                        game.Price,
                        game.ReleaseDate
                     ))
                     // STEP 4: Use AsNoTracking for a read-only query, improving performance.
                     .AsNoTracking());
    }
}
