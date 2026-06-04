// ============================================================================
// DTO: GenreDto (Phase 2 — Using Data Transfer Objects)
//
// Role: Defines the shape of data returned by the GET /genres endpoint.
// Decision rationale: This record intentionally exposes only Id and Name.
// By using a DTO instead of leaking the domain model, the API contract is
// decoupled from internal changes (e.g., adding a domain property for
// Slug won't affect the API response until the DTO is updated).
// ============================================================================

namespace GameStore.API.Features.Genres.GetGenres;

// 'record' gives us value equality and concise syntax (positional parameters).
// Read-only properties ensure the response is immutable after construction.
// Guid Id: unique identifier exposed to clients (not necessarily the DB PK).
// string Name: human-readable genre name, same as domain but deliberately
//   re-typed here to avoid a direct dependency on the domain Genre class.
public record GenreDto(Guid Id, string Name);