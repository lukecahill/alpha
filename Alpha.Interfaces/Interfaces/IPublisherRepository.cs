using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IPublisherRepository : IRespositoryBase<PublisherSummary, PublisherDetails, CreatePublisherBindingModel, UpdatePublisherBindingModel, DeletePublisherBindingModel, int> {
	}
}
