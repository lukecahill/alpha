using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class AccessoriesDetails {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
		public string GameTitle { get; set; }
        public string Description { get; set; }

        public AccessoriesDetails(Accessories accessories) {
            this.AccessoryId = accessories.AccessoryId;
			this.Name = accessories.Name;
			this.GameTitle = accessories.Game.Title;
            this.Description = accessories.Description;
		}
	}
}
