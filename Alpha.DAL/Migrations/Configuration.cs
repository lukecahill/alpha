namespace Alpha.DAL.Migrations {
    using System;
    using System.Data.Entity;
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
                    new Publisher { PublisherId = 1, Name = "Activision", Location = "USA" }
                };
            }
        }

        private IList<Games> GetGames {
            get {
                return new List<Games> {
                    new Games { GameId = 1, PublisherId = 1, Title = "Call of Duty 2", ReleaseDate = DateTime.UtcNow }
                };
            }
        }

        private IList<Addons> GetAddons {
            get {
                return new List<Addons> {
                    new Addons { AddonId = 1, GameId = 1, ReleaseDate = DateTime.UtcNow, Title = "DLC 1" }
                };
            }
        }

        private IList<Accessories> GetAccessories {
            get {
                return new List<Accessories> {
                    new Accessories { AccessoryId = 1, GameId = 1, Name = "Gun", Type = "Gun" }
                };
            }
        }
    }
}
