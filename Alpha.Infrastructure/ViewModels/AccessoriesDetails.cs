using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class AccessoriesDetails {
		public string Name { get; set; }
		public string GameTitle { get; set; }

		public AccessoriesDetails(Accessories accessories) {
			this.Name = accessories.Name;
			this.GameTitle = accessories.Game.Title;
		}
	}
}
