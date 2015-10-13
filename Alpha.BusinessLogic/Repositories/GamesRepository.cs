using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.Infrastructure.ViewModels;
using Alpha.DAL.Context;
using Alpha.Infratructure.BindingModels;
using System.Data.Entity;

namespace Alpha.BusinessLogic.Repositories {
    public class GamesRepository : IGamesRepository {

        private AlphaContext db = new AlphaContext();

        public IEnumerable<GameSummary> GetAll() {
            var entities = db.Games.ToList().Where(g => g.IsDeleted == false);
            return entities.Select(e => new GameSummary(e)).ToList();
        }

        public GameDetails GetById(int id) { 
            var entity = db.Games.FirstOrDefault(g => g.GameId == id);
            if(entity != null) {
			    return new GameDetails(entity);
            }

            return null;
            // TODO: this will of course fail; this is due to the return being a model of the game which does not contain a property for the publishers name. A fix? Use a viewmodel!
        }

        public CreateGameBindingModel Add(CreateGameBindingModel game) {
            var entity = new DAL.Models.Games {
                Title = game.Title,
                PublisherId = game.PublisherId,
                ReleaseDate = game.ReleaseDate
            };

            db.Games.Add(entity);
            db.SaveChanges();

            return game;
        }

        public void Update(UpdateGameBindingModel publisher) {
            throw new NotImplementedException();
        }

        public void Delete(DeleteGameBindingModel publisher) {
            throw new NotImplementedException();
        }

        public void DeleteById(int id) {
            throw new NotImplementedException();
        }
    }
}
