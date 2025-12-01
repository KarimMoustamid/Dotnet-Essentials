namespace GameStore.API.Dtos
{
    using Data;
    using Features.Games.Constants;
    using Models;

    public static class GetGameEndpoint
    {
        public static void MapGetGame(this IEndpointRouteBuilder app, GameStoreData data)
        {
            app.MapGet("/games/{id}",
                (Guid id, GameStoreData data) =>
                {
                    Game? game = data.GetGameById(id);
                    return game is null ? Results.NotFound() : Results.Ok(new GetGameDto(
                        game.Id, game.Name, game.Genre.Id, game.Price, game.ReleaseDate, game.Description));
                }).WithName(EndpointNames.GetGame);
        }
    }
}