// STEP 1: Define the namespace that groups all frontend models together.
namespace GameStore.Frontend.Models;

// STEP 2: Declare an immutable record type to represent the outcome of a command.
// Records provide value equality and a concise syntax for data holders.
public record CommandResult(bool Succeeded)
{
    // STEP 3: Add a mutable list to collect error messages when the operation fails.
    // The list is initialized to empty by default using collection expression.
    public List<string> Errors { get; set; } = [];
}
