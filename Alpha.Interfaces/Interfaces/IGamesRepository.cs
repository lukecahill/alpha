using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IGamesRepository : IRespositoryBase<GameSummary, AddonsDetails, CreateGameBindingModel, UpdateGameBindingModel, DeleteGameBindingModel, int> {
    }
}
