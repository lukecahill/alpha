using Alpha.DAL.Models;
using System;

namespace Alpha.Infrastructure.ViewModels {
    public class AddonSummary {
        public int AddonId { get; set; }
        public string Title { get; set; }
        public string GameTitle { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }

        public AddonSummary(Addons addon) {
            this.AddonId = addon.ExtraId;
            this.Title = addon.Name;
            this.GameTitle = addon.Game.Title;
            this.Publisher = addon.Game.Publisher.Name;
            this.Price = addon.Price;
        }

        public AddonSummary() { }
    }
}