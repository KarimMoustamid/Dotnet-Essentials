using System;
using GameStore.Api.Data;
using GameStore.Api.Features.Games.Constants;
using GameStore.Api.Models;

namespace GameStore.Api.Features.Games.GetGame;

public static class GetGameEndpoint
{
    public static void MapGetGame(this IEndpointRouteBuilder app)
    {
        // GET /games/{id}
        // STEP 1: Register a GET endpoint that accepts an {id} parameter and gives the route a name.
        app.MapGet("/{id}", (Guid id, GameStoreContext dbContext) =>
        {
            // STEP 2: Use Find to locate the game entity by its primary key.
            Game? game = dbContext.Games.Find(id);

            // STEP 3: If no game found, return a 404 Not Found.
            // STEP 4: Otherwise, return a 200 OK with the game details projected to GameDetailsDto.
            return game is null ? Results.NotFound() : Results.Ok(
                new GameDetailsDto(
                    game.Id,
                    game.Name,
                    game.GenreId,
                    game.Price,
                    game.ReleaseDate,
                    game.Description
                )
            );
        })
        .WithName(EndpointNames.GetGame); // ⚠ Forward-ref: EndpointNames.GetGame constant used for route naming.
    }
}
