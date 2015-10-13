using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class PublisherDetails {
		public string Name { get; set; }

		public PublisherDetails(Publisher publisher) {
			this.Name = publisher.Name;
		}
	}
}
