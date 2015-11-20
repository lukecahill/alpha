using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Threading.Tasks;

namespace Alpha.Interfaces.Interfaces {
    public interface IGamesRepository : IRespositoryBase<GameSummary, Task<GameDetails>, CreateGameBindingModel, UpdateGameBindingModel, DeleteGameBindingModel, int> {
    }
}
