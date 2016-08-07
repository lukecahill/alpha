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
			this.GameList = publisher.Games.Select(e => new GameDetails(e)).ToList();
		}

		public PublisherDetails() { }

		public override bool Equals(object obj) {
			if(obj is PublisherDetails) {
				var that = obj as PublisherDetails;
				return this.Location == that.Location && this.Name == that.Name;
			}
			return false;
		}
	}
}