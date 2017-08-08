namespace Alpha.DAL.Migrations {
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Alpha.DAL.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.AlphaContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.AlphaContext context) {
            context.Publishers.AddOrUpdate(GetPublishers.ToArray());
            context.Games.AddOrUpdate(GetGames.ToArray());
            context.Accessories.AddOrUpdate(GetAccessories.ToArray());
            context.Addons.AddOrUpdate(GetAddons.ToArray());
        }

        private IList<Publisher> GetPublishers => new List<Publisher> {
            new Publisher { PublisherId = 1, Name = "Activision", Location = "USA" },
            new Publisher { PublisherId = 2, Name = "SEGA", Location = "USA" },
            new Publisher { PublisherId = 3, Name = "Sierra", Location = "France" }
        };

        private IList<Games> GetGames => new List<Games> {
            new Games { GameId = 1, PublisherId = 1, Title = "Call of Duty 2", ReleaseDate = DateTime.UtcNow, Price = 15.99M },
            new Games { GameId = 2 , PublisherId = 2, Title = "Rome: Total War", ReleaseDate = DateTime.UtcNow, Price = 16M },
            new Games { GameId = 3 , PublisherId = 1, Title = "Call of Duty: Moden Warfare", ReleaseDate = DateTime.UtcNow, Price = 30M },
            new Games { GameId = 4 , PublisherId = 3, Title = "Empire Earth", ReleaseDate = DateTime.UtcNow, Price = 3.50M }
        };

        private IList<Addons> GetAddons => new List<Addons> {
            new Addons { ExtraId = 1, GameId = 1, ReleaseDate = DateTime.UtcNow, Name = "Map Pack 1", Description = "Play the game as it should have been released!", Price = 8.50M },
            new Addons { ExtraId = 2, GameId = 3, ReleaseDate = DateTime.UtcNow, Name = "Map Pack 2", Description = "Explore new places with the map pack", Price = 3.20M },
            new Addons { ExtraId = 3, GameId = 4, ReleaseDate = DateTime.UtcNow, Name = "The Art of Conquest", Description = "Expand to a new frontier: space!", Price = 5.60M }
        };

        private IList<Accessories> GetAccessories => new List<Accessories> {
            new Accessories { ExtraId = 1, GameId = 1, Name = "Gun", Type = "WWII themed gun.", Description = "It is not real.", Price = 9.99M },
            new Accessories { ExtraId = 2, GameId = 2, Name = "Funny hat", Type = "Clothing", Description = "Has absolutly nothing to do with the game.", Price = 3.99M }
        };
    }
}
