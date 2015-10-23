using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IAccessoriesRepository : IRespositoryBase<AccessoriesSummary, AccessoriesDetails, CreateAccessoriesBindingModels, UpdateAccessoriesBindingModels, DeleteAccessoriesBindingModels, int> {
	}
}
