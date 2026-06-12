// ══ STEP 1: Namespace declaration.
namespace GameStore.Api.Models;

// ══ STEP 2: Define the Genre entity class.
public class Genre
{
    // ══ STEP 3: Unique identifier (auto-generated).
    public Guid Id { get; set; }

    // ══ STEP 4: Required name of the genre (e.g., Action, RPG).
    public required string Name { get; set; }
}
