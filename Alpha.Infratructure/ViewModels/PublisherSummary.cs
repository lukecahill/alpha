using Alpha.DAL.Models;

namespace Alpha.Infrastructure.ViewModels {
	public class PublisherSummary {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public PublisherSummary(Publisher publisher) {
            this.PublisherId = publisher.PublisherId;
			this.Name = publisher.Name;
            this.Location = publisher.Location;
		}

		public PublisherSummary() { }

		public override bool Equals(object obj) {
			if (obj is PublisherSummary) {
				var that = obj as PublisherSummary;
				return this.PublisherId == that.PublisherId && this.Name == that.Name;
			}
			return false;
		}
	}
}
