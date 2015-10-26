namespace Alpha.DAL.Migrations {
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Alpha.DAL.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Alpha.DAL.Context.AlphaContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.AlphaContext context) {
            context.Publishers.AddOrUpdate(GetPublishers.ToArray());
            context.Games.AddOrUpdate(GetGames.ToArray());
            context.Accessories.AddOrUpdate(GetAccessories.ToArray());
            context.Addons.AddOrUpdate(GetAddons.ToArray());
        }

        private IList<Publisher> GetPublishers {
            get {
                return new List<Publisher> {
                    new Publisher { PublisherId = 1, Name = "Activision", Location = "USA" },
                    new Publisher { PublisherId = 2, Name = "SEGA", Location = "USA" },
                    new Publisher { PublisherId = 3, Name = "Sierra", Location = "France" }
                };
            }
        }

        private IList<Games> GetGames {
            get {
                return new List<Games> {
                    new Games { GameId = 1, PublisherId = 1, Title = "Call of Duty 2", ReleaseDate = DateTime.UtcNow },
                    new Games { GameId = 2 , PublisherId = 2, Title = "Rome: Total War", ReleaseDate = DateTime.UtcNow },
                    new Games { GameId = 3 , PublisherId = 1, Title = "Call of Duty: Moden Warfare", ReleaseDate = DateTime.UtcNow },
                    new Games { GameId = 4 , PublisherId = 3, Title = "Empire Earth", ReleaseDate = DateTime.UtcNow }
                };
            }
        }

        private IList<Addons> GetAddons {
            get {
                return new List<Addons> {
                    new Addons { AddonId = 1, GameId = 1, ReleaseDate = DateTime.UtcNow, Title = "Map Pack 1", Description = "Play the game as it should have been released!" },
                    new Addons { AddonId = 2, GameId = 3, ReleaseDate = DateTime.UtcNow, Title = "Map Pack 2", Description = "Explore new places with the map pack" },
                    new Addons { AddonId = 3, GameId = 4, ReleaseDate = DateTime.UtcNow, Title = "The Art of Conquest", Description = "Expand to a new frontier: space!" }
                };
            }
        }

        private IList<Accessories> GetAccessories {
            get {
                return new List<Accessories> {
                    new Accessories { AccessoryId = 1, GameId = 1, Name = "Gun", Type = "WWII themed gun.", Description = "It is not real." },
                    new Accessories { AccessoryId = 2, GameId = 2, Name = "Funny hat", Type = "Clothing", Description = "Has absolutly nothing to do with the game." }
                };
            }
        }
    }
}
