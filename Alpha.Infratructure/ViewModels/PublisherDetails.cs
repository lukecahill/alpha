using Alpha.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.Infrastructure.ViewModels {
	public class PublisherDetails {
        public string Name { get; set; }
        public string Location { get; set; }

        public IEnumerable<Games> GameList { get; set; }

        public PublisherDetails(Publisher publisher) {
			this.Name = publisher.Name;
            this.Location = publisher.Location;

            //return the list of addons associated with the publishers ID, if there are any
            if (publisher.Games.Any(g => g.PublisherId == publisher.PublisherId)) {
                this.GameList = publisher.Games.ToList().Where(g => g.PublisherId == publisher.PublisherId);
            }
		}

		public PublisherDetails() { }
	}
}