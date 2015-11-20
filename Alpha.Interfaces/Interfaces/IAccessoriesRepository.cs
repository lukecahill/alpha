using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Threading.Tasks;

namespace Alpha.Interfaces.Interfaces {
    public interface IAccessoriesRepository : IRespositoryBase<AccessoriesSummary, Task<AccessoriesDetails>, CreateAccessoriesBindingModels, UpdateAccessoriesBindingModels, DeleteAccessoriesBindingModels, int> {
	}
}
