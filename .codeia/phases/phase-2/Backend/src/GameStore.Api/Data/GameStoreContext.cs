// ══ File: GameStoreContext.cs ═══════════════════════════════════════
// Defines the Entity Framework Core database context with DbSets for
// Game and Genre entities, acting as the bridge between code and DB.

using System;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// STEP 1: Create a DbContext subclass to manage entity objects during runtime.
//         The primary constructor receives DbContextOptions for configuration.
public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
    : DbContext(options)
{
    // STEP 2: Define DbSet properties for the Game and Genre entities.
    //         These represent tables in the database that EF Core will map to.
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();
}