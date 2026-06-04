// ============================================================
// Phase 2 — Using Data Transfer Objects
// Key concept: DTO records decouple API from domain.
//
// This file defines the public contract that the API exposes
// for the list/grid view of games. It deliberately omits fields
// that the domain tracks internally (e.g. description, tags)
// because the GET endpoint in Phase 2 only needs a summary.
// Separating DTOs from domain entities means:
//   - Domain changes don't automatically change the API shape
//   - Each DTO can be shaped exactly for its consumer (grid vs detail)
//   - Breaking changes to the API are intentional, not accidental
// ============================================================

namespace GameStore.Api.Features.Games.GetGames;

// This record replaces the anonymous objects or full domain entities
// that a first-phase implementation might return. By naming it
// GameSummaryDto, we make the contract explicit and discoverable.
//
// The properties mirror what the API consumer needs for a list view:
// identifier, name, category, price, and release date. Additional
// fields like 'Description' or 'Tags' belong in a detail DTO.
public record GameSummaryDto(
    Guid Id,             // Stable identifier for linking or updates.
    string Name,         // Game title — exposed as-is from domain.
    string Genre,        // Flat string; in a richer model this could be
                         // a structured object, flattened here for simplicity.
    decimal Price,       // Numeric; formatted by the consumer if needed.
    DateOnly ReleaseDate // DateOnly (not DateTime) — communicates that time-of-day
                         // is irrelevant for a release date.
);
