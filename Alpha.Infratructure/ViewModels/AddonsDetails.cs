using System;

namespace Alpha.Infrastructure.ViewModels {
    public class AddonsDetails {

        public int AddonId { get; set; }
        public string AddonName { get; set; }
        public string GameTitle { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public AddonsDetails(DAL.Models.Addons addon) {
            this.AddonId = addon.AddonId;
            this.AddonName = addon.Title;
            this.GameTitle = addon.Game.Title;
            this.Publisher = addon.Game.Publisher.Name;
            this.Description = addon.Description;
            this.ReleaseDate = addon.ReleaseDate;
        }

        public AddonsDetails() { }
    }
}
