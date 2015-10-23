using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IGamesRepository : IRespositoryBase<GameSummary, GameDetails, CreateGameBindingModel, UpdateGameBindingModel, DeleteGameBindingModel, int> {
    }
}
