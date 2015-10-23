using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IAddonsRepository : IRespositoryBase<AddonSummary, AddonsDetails, CreateAddonBindingModel, UpdateAddonBindingModel, DeleteAddonBindingModel, int> {
    }
}
