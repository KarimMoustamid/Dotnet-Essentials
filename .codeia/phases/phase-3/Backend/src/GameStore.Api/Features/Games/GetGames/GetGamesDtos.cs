namespace GameStore.Api.Features.Games.GetGames;

// STEP 1: Define a summary DTO for listing games, including the genre name instead of just the ID.
public record GameSummaryDto(
    Guid Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
