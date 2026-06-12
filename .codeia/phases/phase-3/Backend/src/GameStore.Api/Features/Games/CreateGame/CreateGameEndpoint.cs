using GameStore.Api.Data;
using GameStore.Api.Features.Games.Constants;
using GameStore.Api.Models;

namespace GameStore.Api.Features.Games.CreateGame;

public static class CreateGameEndpoint
{
    // STEP 1: Register a POST endpoint for games using an extension method.
    public static void MapCreateGame(this IEndpointRouteBuilder app)
    {   
        // POST /games
        // STEP 2: Map the POST route at the root of the group (the prefix "/games" will be added by the group in GamesEndpoints).
        app.MapPost("/", (
            CreateGameDto gameDto, 
            GameStoreContext dbContext) =>
        {
            // STEP 3: Map the incoming DTO to a new Game entity.
            var game = new Game
            {
                Name = gameDto.Name,
                GenreId = gameDto.GenreId,    // ⚠ Forward-ref: GenreId is a foreign key to the Genres table (model defined in Data/Models)
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                Description = gameDto.Description
            };

            // STEP 4: Add the new game to the database context's Games collection.
            dbContext.Games.Add(game);

            // STEP 5: Save changes to the database, which generates the game's Id.
            dbContext.SaveChanges();

            // STEP 6: Return a 201 Created response with the URI of the new resource (via route name) and a GameDetailsDto body.
            return Results.CreatedAtRoute(
                EndpointNames.GetGame,   // ⚠ Forward-ref: EndpointNames.GetGame is defined in Constants/EndpointNames.cs
                new { id = game.Id },
                new GameDetailsDto(
                    game.Id,
                    game.Name,
                    game.GenreId,
                    game.Price,
                    game.ReleaseDate,
                    game.Description
                ));
        })
        .WithParameterValidation();  // Enables automatic validation based on data annotations.
    }
}
