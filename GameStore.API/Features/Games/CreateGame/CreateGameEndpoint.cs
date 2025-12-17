namespace GameStore.API.Features.Games.CreateGame
{
    using Data;
    using Features.Games.Constants;
    using Models;
    using Dtos;

    public static class CreateGameEndpoint
    {
        public static void MapCreateGame(this IEndpointRouteBuilder app)
        {
            app.MapPost("/",
                (GameStoreContext dbContext, CreateGameDto gameDto, GameDataLogger logger) =>
                {
                    var game = new Game()
                    {
                        Name = gameDto.Name,
                        GenreId = gameDto.GenreId,
                        Price = gameDto.Price,
                        ReleaseDate = gameDto.ReleaseDate,
                        Description = gameDto.Description
                    };

                    dbContext.Games.Add(game);
                    dbContext.SaveChanges();


                    logger.PrintGames();

                    return Results.CreatedAtRoute(EndpointNames.GetGame, new { id = game.Id}, new GameDetailsDto(
                        game.Id, game.Name, game.GenreId, game.Price, game.ReleaseDate, game.Description));
                }).WithParameterValidation();
        }
    }
}