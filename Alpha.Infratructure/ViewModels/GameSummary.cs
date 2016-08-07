using Alpha.DAL.Models;
using System;

namespace Alpha.Infrastructure.ViewModels {
    public class GameSummary {
		public int GameId { get; set; }
		public string Title { get; set; }
        public string PublisherName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }

        public GameSummary(Games game) {
			this.GameId = game.GameId;
            this.Title = game.Title;
            this.PublisherName = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;
            this.Price = game.Price;
        }

		public GameSummary() { }
		public override bool Equals(object obj) {
			if (obj is GameSummary) {
				var that = obj as GameSummary;
				return this.GameId == that.GameId && this.Title == that.Title;
			}
			return false;
		}
	}
}
