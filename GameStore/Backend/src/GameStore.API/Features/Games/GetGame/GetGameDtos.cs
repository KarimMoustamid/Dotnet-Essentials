// ============================================================================
// Step 2 — Using Data Transfer Objects
//
// Role: Defines the public contract for the 'get game by ID' endpoint.
// This DTO decouples the API response from the Game domain entity.
// Changes to the domain model will not affect API consumers as long
// as the mapping logic (in the endpoint handler) selects the right fields.
// ============================================================================

namespace GameStore.Api.Features.Games.GetGame;

// GameDetailsDto — the response shape returned by GET /games/{id}.
// It is a record to get value equality and concise syntax.
// Why a DTO instead of exposing the domain entity directly?
//   - We control what fields are visible to the client.
//   - The domain entity may contain internal state (e.g. timestamps,
//     concurrency tokens) that should never be serialized.
//   - We can rename, flatten, or combine fields without touching the domain.
//     Here, we expose GenreId (a Guid) rather than a navigation object —
//     the client looks up genre details via a separate endpoint.
public record GameDetailsDto(
    Guid Id,
    string Name,
    Guid GenreId,
    decimal Price,
    DateOnly ReleaseDate,
    string Description
);
// Note: No imports are needed because all types (Guid, decimal, DateOnly)
// are built into the BCL and the record keyword requires no using.
// The namespace 'GameStore.Api.Features.Games.GetGame' scopes this DTO
// to the 'get game' operation, following the Vertical Slices convention
// where each operation owns its own request/response types.
