// ══ File: DataExtensions.cs ═════════════════════════════════════════
// Provides extension methods to initialise the database by applying
// migrations and seeding initial genre data during application startup.

using System;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    // STEP 1: Main initialisation method to be called during app startup.
    //         It runs migrations and seeds the database.
    public static void InitializeDb(this WebApplication app)
    {
        // STEP 2: Apply any pending database migrations first.
        app.MigrateDb();
        // STEP 3: Then seed initial data (genres).
        app.SeedDb();
    }

    // STEP 2: MigrateDb creates a service scope to resolve the database context,
    //         then calls Database.Migrate() to apply all pending migrations.
    private static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider
                                          .GetRequiredService<GameStoreContext>();
        // ⚠ Forward-ref: Database.Migrate() is provided by EF Core and will execute
        //               migration files like InitialCreate to create tables.
        dbContext.Database.Migrate();
    }

    // STEP 3: SeedDb checks if any genres exist, and if not, adds a set of default genres.
    //         Uses the same scoped resolution as MigrateDb.
    private static void SeedDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider
                                          .GetRequiredService<GameStoreContext>();

        if (!dbContext.Genres.Any())
        {
            // STEP 4: Add predefined genre entities to the context.
            dbContext.Genres.AddRange(
                new Genre { Name = "Fighting" },
                new Genre { Name = "Kids and Family" },
                new Genre { Name = "Racing" },
                new Genre { Name = "Roleplaying" },
                new Genre { Name = "Sports" }
            );

            // STEP 5: Persist the changes to the database.
            dbContext.SaveChanges();
        }
    }
}