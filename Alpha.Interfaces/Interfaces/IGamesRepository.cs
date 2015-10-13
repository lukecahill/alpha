using Alpha.Infrastructure.ViewModels;
using Alpha.Infratructure.BindingModels;
using System.Collections.Generic;

namespace Alpha.Interfaces.Interfaces {
    public interface IGamesRepository {// : IRespositoryBase<Games, int> {
        IEnumerable<GameSummary> GetAll();
        GameDetails GetById(int id);
        CreateGameBindingModel Add(CreateGameBindingModel obj);
        void Update(UpdateGameBindingModel obj);
        void Delete(DeleteGameBindingModel obj);
        void DeleteById(int id);
    }
}
