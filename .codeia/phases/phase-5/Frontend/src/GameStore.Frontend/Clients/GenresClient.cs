// ══ STEP 1: Import models namespace for Genre type
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

// ══ STEP 2: Define GenresClient with primary constructor injecting HttpClient
public class GenresClient(HttpClient httpClient)
{
    // ══ STEP 3: Fetch all genres from GET /genres, return empty array if null
    public async Task<Genre[]> GetGenresAsync() 
        => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
}
