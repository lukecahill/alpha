using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class AccessoriesSummary {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
		public string GameTitle { get; set; }

		public AccessoriesSummary(Accessories accessories) {
            this.AccessoryId = accessories.ExtraId;
			this.Name = accessories.Name;
			this.GameTitle = accessories.Game.Title;
		}
	}
}
