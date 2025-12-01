namespace GameStore.API.Features.Genres
{
    using GetGenres;

    public static class GenresEndpoints
    {
        public static void MapGenres(this IEndpointRouteBuilder app)
        {
            app.MapGetGenres();
        }
    }
}