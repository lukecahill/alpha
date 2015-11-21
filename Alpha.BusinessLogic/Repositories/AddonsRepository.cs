using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.DAL.Context;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Globalization;
using System.Threading.Tasks;

namespace Alpha.BusinessLogic.Repositories {
    public class AddonsRepository : IDisposable, IAddonsRepository {

        private readonly AlphaContext db = new AlphaContext();

        public IEnumerable<AddonSummary> GetAll() {
            var entities = db.Addons
                .Include(g => g.Game)
                .Include(a => a.Game.Publisher)
                .ToList()
                .Where(a => a.IsDeleted == false);

            return entities.Select(e => new AddonSummary(e)).ToList();
        }

        public async Task<AddonsDetails> GetById(int id) {
			var entity = await db.Addons
                .Include(g => g.Game).Where(g => g.IsDeleted == false)
                .Include(g => g.Game.Publisher).Where(g => g.IsDeleted == false)
                .Where(a => a.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.ExtraId == id);

            if(entity != null) {
                return new AddonsDetails(entity);
            }

            return null;
        }

        public CreateAddonBindingModel Add(CreateAddonBindingModel addon) {
            var pattern = "dd-MM-yy";
            DateTime returnDate;

            if (!DateTime.TryParseExact(addon.ReleaseDate, pattern, null, DateTimeStyles.None, out returnDate)) {
                returnDate = DateTime.UtcNow;
            }

            var entity = new DAL.Models.Addons {
                Name = addon.Name,
                GameId = addon.GameId,
                ReleaseDate = returnDate,
                Description = addon.Description,
                Price = addon.Price
            };

            db.Addons.Add(entity);
            db.SaveChanges();

            return addon;
        }

        public void Update(UpdateAddonBindingModel addon) {
            var pattern = "dd-MM-yy";
            DateTime returnDate;

            if (!DateTime.TryParseExact(addon.ReleaseDate, pattern, null, DateTimeStyles.None, out returnDate)) {
                returnDate = DateTime.UtcNow;
            }

            var entity = db.Addons.FirstOrDefault(a => a.ExtraId == addon.AddonId);

            entity.Name = addon.Name;
            entity.Description = addon.Description;
            entity.GameId = addon.GameId;
            entity.ReleaseDate = returnDate;
            entity.Price = addon.Price;

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(DeleteAddonBindingModel addon) {
            var entity = db.Addons.FirstOrDefault(a => a.ExtraId == addon.AddonId);

            db.Addons.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = db.Addons.FirstOrDefault(a => a.ExtraId == id);

            db.Addons.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
