namespace GameStore.Api.Features.Genres.GetGenres;

// STEP 1: Define the DTO for a genre, exposing Id and Name.
public record GenreDto(Guid Id, string Name);
