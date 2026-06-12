using GameStore.Api.Data;

namespace GameStore.Api.Features.Games.UpdateGame;

public static class UpdateGameEndpoint
{
    public static void MapUpdateGame(this IEndpointRouteBuilder app)
    {
        // PUT /games/{id}
        // STEP 1: Map the PUT route with an {id} parameter.
        app.MapPut("/{id}", (Guid id, UpdateGameDto gameDto, GameStoreContext dbContext) =>
        {
            // STEP 2: Find the existing game entity by its Id.
            var existingGame = dbContext.Games.Find(id);

            // STEP 3: If not found, return 404 Not Found.
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            // STEP 4: Update the entity’s properties from the DTO.
            existingGame.Name = gameDto.Name;
            existingGame.GenreId = gameDto.GenreId;
            existingGame.Price = gameDto.Price;
            existingGame.ReleaseDate = gameDto.ReleaseDate;
            existingGame.Description = gameDto.Description;

            // STEP 5: Save changes to the database.
            dbContext.SaveChanges();

            // STEP 6: Return 204 No Content to indicate success with no body.
            return Results.NoContent();
        })
        .WithParameterValidation();  // Validate the input DTO using its data annotations.
    }
}
