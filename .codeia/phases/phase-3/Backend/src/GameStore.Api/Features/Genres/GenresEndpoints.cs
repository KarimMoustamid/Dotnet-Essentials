using System;
using GameStore.Api.Data;
using GameStore.Api.Features.Genres.GetGenres;
using GameStore.Api.Models;

namespace GameStore.Api.Features.Genres;

public static class GenresEndpoints
{
    // STEP 1: Extension method to group genre endpoints under a common prefix.
    public static void MapGenres(this IEndpointRouteBuilder app)
    {
        // STEP 2: Create a route group with the prefix "/genres".
        var group = app.MapGroup("/genres");

        // STEP 3: Map the get genres endpoint inside the group.
        group.MapGetGenres();
    }
}
