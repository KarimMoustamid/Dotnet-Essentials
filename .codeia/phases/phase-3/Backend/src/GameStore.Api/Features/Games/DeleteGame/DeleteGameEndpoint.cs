using System;
using GameStore.Api.Data;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
    public static void MapDeleteGame(this IEndpointRouteBuilder app)
    {
        // DELETE /games/{id}
        // STEP 1: Register a DELETE endpoint at the path with an {id} parameter.
        app.MapDelete("/{id}", (Guid id, GameStoreContext dbContext) =>
        {
            // STEP 2: Execute a raw SQL DELETE via ExecuteDelete to remove the record directly from the database.
            dbContext.Games
                     .Where(game => game.Id == id)
                     .ExecuteDelete();

            // STEP 3: Return a 204 No Content response indicating successful deletion.
            return Results.NoContent();
        });
    }
}
