using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Threading.Tasks;

namespace Alpha.Interfaces.Interfaces {
    public interface IAddonsRepository : IRespositoryBase<AddonSummary, Task<AddonsDetails>, CreateAddonBindingModel, UpdateAddonBindingModel, DeleteAddonBindingModel, int> {
    }
}
