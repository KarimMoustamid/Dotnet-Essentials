namespace GameStore.Api.Features.Games.GetGame;

// STEP 1: Define the GameDetailsDto record used as the response body for GetGame and CreateGame.
public record GameDetailsDto(
    Guid Id,
    string Name,
    Guid GenreId,
    decimal Price,
    DateOnly ReleaseDate,
    string Description);
