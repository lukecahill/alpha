using Alpha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.Infrastructure.ViewModels {
    public class GameDetails {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<AddonsDetails> AddonList { get; set; }
        public IEnumerable<AccessoriesDetails> AccessoryList { get; set; }

        public GameDetails(Games game) {
            this.Title = game.Title;
            this.Publisher = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;
            this.PictureLink = game.PictureLink;
            this.Price = game.Price;
			this.AddonList = game.Addons.Select(e => new AddonsDetails(e)).ToList();
			this.AccessoryList = game.Accessories.Select(e => new AccessoriesDetails(e)).ToList();
        }

        public GameDetails() { }
    }
}
