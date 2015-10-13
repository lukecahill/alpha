using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
    public class GameDetails {
        public string Title { get; set; }
        public string Publisher { get; set; }

        public GameDetails(Games game) {
            this.Title = game.Title;
            this.Publisher = game.Publisher.Name;
        }
    }
}
