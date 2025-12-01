namespace GameStore.API.Data
{
    using Models;

    public class GameStoreData
    {

         private readonly List<Genre> genres = new List<Genre>
        {
            new Genre { Id = Guid.NewGuid(), Name = "RPG" },
            new Genre { Id = Guid.NewGuid(), Name = "Action RPG" },
            new Genre { Id = Guid.NewGuid(), Name = "Roguelike" }
        };

        private readonly List<Game> games;

        public GameStoreData()
        {
           games = new List<Game>
               {
                   new Game
                   {
                       Id = Guid.NewGuid(),
                       Name = "The Witcher 3: Wild Hunt",
                       Genre = genres[0],
                       Price = 39.99M,
                       Description = "Open-world action role-playing game set in a dark fantasy world.",
                       ReleaseDate = new DateOnly(2015, 5, 19)
                   },
                   new Game
                   {
                       Id = Guid.NewGuid(),
                       Name = "Cyberpunk 2077",
                       Genre = genres[1],
                       Price = 59.99M,
                       Description = "Futuristic open-world action RPG set in Night City.",
                       ReleaseDate = new DateOnly(2020, 12, 10)
                   },
                   new Game
                   {
                       Id = Guid.NewGuid(),
                       Name = "Hades",
                       Genre = genres[2],
                       Price = 24.99M,
                       Description = "Roguelike dungeon crawler where players fight through the underworld.",
                       ReleaseDate = new DateOnly(2020, 9, 17)
                   }
               };
        }

        #region Games (CRUD operations)

        public IEnumerable<Game> GetAllGames() => games;
        public Game? GetGameById(Guid id) => games.Find(g => g.Id == id);

        public void AddGame(Game game)
        {
            game.Id = Guid.NewGuid();
            games.Add(game);
        }

        public void RemoveGame(Guid id) => games.RemoveAll(g => g.Id == id);

        #endregion

        #region Genres (reference data)

        public IEnumerable<Genre> GetAllGenres() => genres;
        public Genre? GetGenreById(Guid id) => genres.Find(g => g.Id == id);
        #endregion

    }
}