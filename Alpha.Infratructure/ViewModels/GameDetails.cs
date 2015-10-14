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
        
        public GameDetails(Games game) {
            this.Title = game.Title;
            if(game.Addons.Any(g => g.GameId == game.GameId)) {
                this.AddonList = game.Addons.ToList().Where(g => g.GameId == game.GameId);
            }
            this.Publisher = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;
        }
    }
}
