using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class PublisherSummary {
		public string Name { get; set; }

		public PublisherSummary(Publisher publisher) {
			this.Name = publisher.Name;
		}
	}
}
