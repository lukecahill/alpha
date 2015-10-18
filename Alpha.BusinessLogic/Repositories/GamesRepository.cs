using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.Infrastructure.ViewModels;
using Alpha.DAL.Context;
using Alpha.Infrastructure.BindingModels;
using System.Data.Entity;
using System.Globalization;

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
        }

        public CreateGameBindingModel Add(CreateGameBindingModel game) {
            var pattern = "dd-MM-yy";
            DateTime returnDate;

            if(!DateTime.TryParseExact(game.ReleaseDate, pattern, null, DateTimeStyles.None, out returnDate)) {
                returnDate = DateTime.UtcNow;
            }

            var entity = new DAL.Models.Games {
                Title = game.Title,
                PublisherId = game.PublisherId,
                ReleaseDate = returnDate
            };

            db.Games.Add(entity);
            db.SaveChanges();

            return game;
        }

        public void Update(UpdateGameBindingModel publisher) {
            var pattern = "dd-MM-yy";
            DateTime returnDate;

            if (!DateTime.TryParseExact(publisher.ReleaseDate, pattern, null, DateTimeStyles.None, out returnDate)) {
                returnDate = DateTime.UtcNow;
            }

            var entity = db.Games.FirstOrDefault(g => g.GameId == publisher.GameId);

            entity.Title = publisher.Title;
            entity.ReleaseDate = returnDate;
            entity.PublisherId = publisher.PublisherId;

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(DeleteGameBindingModel publisher) {
            var entity = db.Games.FirstOrDefault(p => p.GameId == publisher.GameId);

            db.Games.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = db.Games.FirstOrDefault(p => p.GameId == id);

            db.Games.Remove(entity);
            db.SaveChanges();
        }
    }
}
