using System;

namespace Alpha.Infrastructure.ViewModels {
    public class AddonsDetails {

        public int AddonId { get; set; }
        public string AddonName { get; set; }
        public string GameTitle { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public AddonsDetails(DAL.Models.Addons addon) {
            this.AddonId = addon.ExtraId;
            this.AddonName = addon.Name;
            this.GameTitle = addon.Game.Title;
            this.Publisher = addon.Game.Publisher.Name;
            this.Description = addon.Description;
            this.ReleaseDate = addon.ReleaseDate;
            this.Price = addon.Price;
        }

        public AddonsDetails() { }
    }
}
