using System;
using GameStore.Api.Data;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        // GET /genres
        // STEP 1: Map the GET request to the root of the group.
        app.MapGet("/", (GameStoreContext dbContext) =>
            // STEP 2: Query the Genres table and project each to a GenreDto.
            dbContext.Genres
                     .Select(genre => new GenreDto(genre.Id, genre.Name))
                     // STEP 3: Mark the query as read-only for performance.
                     .AsNoTracking());
    }
}
