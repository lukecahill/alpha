using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class AccessoriesDetails {

        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string GameTitle { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public AccessoriesDetails(Accessories accessories) {
            this.AccessoryId = accessories.ExtraId;
            this.Publisher = accessories.Game.Publisher.Name;
			this.Name = accessories.Name;
			this.GameTitle = accessories.Game.Title;
            this.Description = accessories.Description;
            this.Type = accessories.Type;
            this.Price = accessories.Price;
		}

        public AccessoriesDetails() { }
	}
}
