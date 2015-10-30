using Alpha.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.Infrastructure.ViewModels {
	public class PublisherDetails {
        public string Name { get; set; }
        public string Location { get; set; }

        public IEnumerable<GameDetails> GameList { get; set; }

        public PublisherDetails(Publisher publisher) {
			this.Name = publisher.Name;
            this.Location = publisher.Location;

            //return the list of addons associated with the publishers ID, if there are any
            if (publisher.Games.Any(g => g.PublisherId == publisher.PublisherId)) {
                var list = new List<GameDetails>();

                var listOfGames = publisher.Games.ToList().Where(g => g.PublisherId == publisher.PublisherId && g.IsDeleted == false);

                foreach (var item in listOfGames) {
                    var entity = new GameDetails {
                        Publisher = this.Name,
                        Title = item.Title,
                        ReleaseDate = item.ReleaseDate
                    };
                    list.Add(entity);
                }

                GameList = list;
            }
		}

		public PublisherDetails() { }
	}
}