using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class AccessoriesSummary {
		public string Name { get; set; }
		public string GameTitle { get; set; }

		public AccessoriesSummary(Accessories accessories) {
			this.Name = accessories.Name;
			this.GameTitle = accessories.Game.Title;
		}
	}
}
