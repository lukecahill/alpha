using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Collections.Generic;

namespace Alpha.Interfaces.Interfaces {
    public interface IPublisherRepository { //: IRespositoryBase<Publisher, int> {
		IEnumerable<PublisherSummary> GetAll();
		PublisherDetails GetById(int id);
		CreatePublisherBindingModel Add(CreatePublisherBindingModel obj);
		void Update(PublisherDetails obj);
		void Delete(PublisherDetails obj);
		void DeleteById(int id);

	}
}
