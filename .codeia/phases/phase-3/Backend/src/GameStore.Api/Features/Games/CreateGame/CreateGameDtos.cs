using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Features.Games.CreateGame;

// STEP 1: Define the input DTO for creating a game, with validation attributes for Name, Price, and Description.
public record CreateGameDto(
    [Required][StringLength(50)] string Name,
    Guid GenreId,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate,
    [Required][StringLength(500)] string Description
);

// STEP 2: Define the output DTO returned after creating a game, containing the generated Id and all game details.
public record GameDetailsDto(
    Guid Id,
    string Name,
    Guid GenreId,
    decimal Price,
    DateOnly ReleaseDate,
    string Description);
