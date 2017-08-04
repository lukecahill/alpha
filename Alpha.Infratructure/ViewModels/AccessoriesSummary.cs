using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class AccessoriesSummary {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
		public string GameTitle { get; set; }
        public decimal Price { get; set; }

        public AccessoriesSummary(Accessories accessories) {
            this.AccessoryId = accessories.ExtraId;
			this.Name = accessories.Name;
			this.GameTitle = accessories.Game.Title;
            this.Price = accessories.Price;
		}

		public AccessoriesSummary() {	}

		public override bool Equals(object obj) {
			if (obj is AccessoriesSummary) {
				var that = obj as AccessoriesSummary;
				return this.AccessoryId == that.AccessoryId && this.Name == that.Name;
			}
			return false;
		}
	}
}
