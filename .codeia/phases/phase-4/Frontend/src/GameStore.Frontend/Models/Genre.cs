// STEP 1: Namespace for all frontend models.
namespace GameStore.Frontend.Models;

// STEP 2: A minimal model representing a genre option.
// This class will be used to populate dropdowns and to map the GenreId in GameDetails.
public class Genre
{
    // STEP 3: Unique identifier for the genre.
    public Guid Id { get; set; }

    // STEP 4: Display name of the genre (e.g., "Action", "RPG").
    public required string Name { get; set; }
}
