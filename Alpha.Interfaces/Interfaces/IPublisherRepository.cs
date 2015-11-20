using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Threading.Tasks;

namespace Alpha.Interfaces.Interfaces {
    public interface IPublisherRepository : IRespositoryBase<PublisherSummary, Task<PublisherDetails>, CreatePublisherBindingModel, UpdatePublisherBindingModel, DeletePublisherBindingModel, int> {
	}
}
