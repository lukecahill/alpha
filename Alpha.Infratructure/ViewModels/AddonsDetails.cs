namespace Alpha.Infrastructure.ViewModels {
    public class AddonsDetails {

        public string AddonName { get; set; }
        public string GameTitle { get; set; }
        public string Publisher { get; set; }

        public AddonsDetails(DAL.Models.Addons addon) {
            this.AddonName = addon.Title;
            this.GameTitle = addon.Game.Title;
            this.Publisher = addon.Game.Publisher.Name;
        }
    }
}
