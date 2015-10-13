using Alpha.DAL.Models;
using System;

namespace Alpha.Infrastructure.ViewModels {
    public class GameSummary {
		public int GameId { get; set; }
		public string Title { get; set; }
        public string PublisherName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public GameSummary(Games game) {
			this.GameId = game.GameId;
            this.Title = game.Title;
            this.PublisherName = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;
        }
    }
}
