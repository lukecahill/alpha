using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.Infrastructure.ViewModels;
using Alpha.DAL.Context;
using Alpha.Infrastructure.BindingModels;
using System.Data.Entity;
using System.Globalization;
using System.Threading.Tasks;

namespace Alpha.BusinessLogic.Repositories {
    public class GamesRepository : IGamesRepository {

        private AlphaContext db = new AlphaContext();

        public IEnumerable<GameSummary> GetAll() {
            var entities = db.Games
                .Include(p => p.Publisher)
                .ToList()
                .Where(g => g.IsDeleted == false);

            return entities.Select(e => new GameSummary(e)).ToList();
        }

        public async Task<GameDetails> GetById(int id) {
            var entity = await db.Games.Include(p => p.Publisher)
                .Include(a => a.Accessories).Where(a => a.IsDeleted == false)
                .Include(a => a.Addons).Where(a => a.IsDeleted == false)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync(g => g.GameId == id);

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
                ReleaseDate = returnDate,
                PictureLink = game.PictureLink,
                Price = game.Price
            };

            db.Games.Add(entity);
            db.SaveChanges();

            return game;
        }

        public void Update(UpdateGameBindingModel game) {
            var pattern = "dd-MM-yy";
            DateTime returnDate;

            if (!DateTime.TryParseExact(game.ReleaseDate, pattern, null, DateTimeStyles.None, out returnDate)) {
                returnDate = DateTime.UtcNow;
            }

            var entity = db.Games.FirstOrDefault(g => g.GameId == game.GameId);

            entity.Title = game.Title;
            entity.ReleaseDate = returnDate;
            entity.PublisherId = game.PublisherId;
            entity.PictureLink = game.PictureLink;
            entity.Price = game.Price;

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(DeleteGameBindingModel game) {
            var entity = db.Games.FirstOrDefault(p => p.GameId == game.GameId);

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
