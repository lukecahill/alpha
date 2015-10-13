namespace Alpha.Infrastructure.ViewModels {
    public class GameSummary {
        public string Title { get; set; }
        public string PublisherName { get; set; }

        public GameSummary(DAL.Models.Games game) {
            this.Title = game.Title;
            this.PublisherName = game.Publisher.Name;
        }
    }
}
