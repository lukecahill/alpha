using Alpha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.Infrastructure.ViewModels {
    public class GameDetails {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public IEnumerable<Addons> AddonList { get; set; }
        public IEnumerable<Accessories> AccessoryList { get; set; }

        public GameDetails(Games game) {
            this.Title = game.Title;
            this.Publisher = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;

            // return the list of addons associated with the games ID, if any
            if (game.Addons.Any(g => g.GameId == game.GameId)) {
                this.AddonList = game.Addons.ToList().Where(g => g.GameId == game.GameId);
            }

            // return the list of accessories associated with the games ID, if any
            if (game.Accessories.Any(g => g.GameId ==- game.GameId)) {
                this.AccessoryList = game.Accessories.ToList().Where(g => g.GameId == game.GameId);
            }
        }
    }
}
