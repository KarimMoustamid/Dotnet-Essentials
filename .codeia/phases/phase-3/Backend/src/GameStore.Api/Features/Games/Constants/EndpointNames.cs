using System;

namespace GameStore.Api.Features.Games.Constants;

// STEP 1: Define a static class to hold endpoint name constants, ensuring consistent route names.
public static class EndpointNames
{
    // STEP 2: Provide a constant for the GetGame endpoint route name, using nameof for compile-time safety.
    public const string GetGame = nameof(GetGame);
}
