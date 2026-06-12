// ══ STEP 1: Import models namespace to use GameSummary, GameDetails, CommandResult
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

// ══ STEP 2: Define the GamesClient class that uses a typed HttpClient
//           The primary constructor injects HttpClient, which is configured in DI
public class GamesClient(HttpClient httpClient)
{
    // ══ STEP 3: A default error detail used in CommandResult when errors are unknown
    private readonly List<string> defaultDetail = ["Unknown error."];

    // ══ STEP 4: Retrieve all games as an array of GameSummary from GET /games
    //           Returns an empty array if the response is null (no content)
    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>($"games") ?? [];

    // ══ STEP 5: Add a new game via POST /games
    //           Uses PostAsJsonAsync to serialize the GameDetails object to JSON
    //           The response is handled by the extension method HandleAsync (see STEP 9)
    public async Task<CommandResult> AddGameAsync(GameDetails game)
    {
        var response = await httpClient.PostAsJsonAsync("games", game);
        return await response.HandleAsync();
    }

    // ══ STEP 6: Get a single game by ID from GET /games/{id}
    //           Throws if the response is null (game not found)
    public async Task<GameDetails> GetGameAsync(Guid id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
            ?? throw new Exception("Could not find game!");

    // ══ STEP 7: Update an existing game via PUT /games/{id}
    //           The updated game includes its Id to construct the URL
    public async Task<CommandResult> UpdateGameAsync(GameDetails updatedGame)
    {
        var response = await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
        return await response.HandleAsync();
    }

    // ══ STEP 8: Delete a game via DELETE /games/{id}
    public async Task<CommandResult> DeleteGameAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"games/{id}");
        return await response.HandleAsync();
    }
}
