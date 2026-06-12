// STEP 1: Namespace declaration for frontend models.
namespace GameStore.Frontend.Models;

// STEP 2: This plain class serves as a lightweight data transfer object for displaying game lists.
// It contains only the fields needed for summary views, without validation attributes.
public class GameSummary
{
    // STEP 3: Unique identifier of the game.
    public Guid Id { get; set; }

    // STEP 4: Game name for display.
    public required string Name { get; set; }

    // STEP 5: Genre name (pre‑resolved string) for showing in lists.
    public required string Genre { get; set; }

    // STEP 6: Price of the game.
    public decimal Price { get; set; }

    // STEP 7: Release date of the game.
    public DateOnly ReleaseDate { get; set; }
}
