// STEP 1: Import the DataAnnotations namespace for model validation attributes.
using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models;

// STEP 2: Create a class to hold detailed game information, including validation rules.
public class GameDetails
{
    // STEP 3: Include a unique identifier matching the backend DTO.
    public Guid Id { get; set; }

    // STEP 4: Add the game's name with validation: it's required and limited to 50 characters.
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    // STEP 5: Add a nullable GenreId to allow for an unselected genre.
    // The Required attribute forces a selection; a custom error message is provided.
    // ⚠ Forward-ref: GenreId will be validated against the available Genre list from the API (Step: Genre.cs).
    [Required(ErrorMessage = "The Genre field is required.")]
    public Guid? GenreId { get; set; }

    // STEP 6: Add a price field constrained to a range between 1 and 100.
    [Range(1, 100)]
    public decimal Price { get; set; }

    // STEP 7: Add a release date property with no validation constraints.
    public DateOnly ReleaseDate { get; set; }

    // STEP 8: Add a description that is required and limited to 500 characters.
    [Required]
    [StringLength(500)]
    public required string Description { get; set; }
}
