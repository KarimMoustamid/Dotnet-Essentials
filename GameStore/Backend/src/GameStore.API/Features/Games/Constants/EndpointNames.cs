// ============================================================================
// EndpointNames.cs
// Phase 2 — Using Data Transfer Objects
//
// This class centralizes the symbolic name of every route so that controllers,
// tests, and link-generation code all refer to the same string. Without this,
// a typo in an endpoint attribute or a test would silently fail at runtime
// (e.g., return a 404 instead of a 201 Created with a Location header).
// ============================================================================

using System;

namespace GameStore.Api.Features.Games.Constants;

public static class EndpointNames
{
    // nameof(GetGame) compiles to the string "GetGame".
    // Using nameof instead of a literal means renaming the constant automatically
    // updates all references — there is no hard-coded string to miss.
    public const string GetGame = nameof(GetGame);
}
