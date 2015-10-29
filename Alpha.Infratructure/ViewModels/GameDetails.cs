using Alpha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.Infrastructure.ViewModels {
    public class GameDetails {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public IEnumerable<AddonsDetails> AddonList { get; set; }
        public IEnumerable<AccessoriesDetails> AccessoryList { get; set; }

        public GameDetails(Games game) {
            this.Title = game.Title;
            this.Publisher = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;

            // return the list of addons associated with the games ID, if any
            if (game.Addons.Any(g => g.GameId == game.GameId)) {

                // there is probably a better ay of doing the below, but I do not know it yet
                var list = new List<AddonsDetails>();
                var ListofAddons = game.Addons.ToList().Where(g => g.GameId == game.GameId && g.IsDeleted == false);

                foreach (var item in ListofAddons) {
                    var entity = new AddonsDetails {
                        AddonId = item.ExtraId,
                        GameTitle = this.Title,
                        AddonName = item.Name,
                        Description = item.Description,
                        Publisher = this.Publisher,
                        ReleaseDate = item.ReleaseDate
                    };

                    list.Add(entity);
                    this.AddonList = list;
                }
            }

            // return the list of accessories associated with the games ID, if any 
            if (game.Accessories.Any(g => g.GameId == game.GameId)) {
                var list = new List<AccessoriesDetails>();
                var ListOfAccessories = game.Accessories.ToList().Where(g => g.GameId == game.GameId && g.IsDeleted == false);

                foreach (var item in ListOfAccessories) {
                    var entity = new AccessoriesDetails {
                        AccessoryId = item.ExtraId,
                        Description = item.Description,
                        Name = item.Name,
                        GameTitle = this.Title,
                        Publisher = this.Publisher
                    };

                    list.Add(entity);
                    this.AccessoryList = list;
                }
            }
        }

        public GameDetails() { }
    }
}
