using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.DAL.Context;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using System.Globalization;

namespace Alpha.BusinessLogic.Repositories {
    public class AddonsRepository : IAddonsRepository {
        private AlphaContext db = new AlphaContext();

        public IEnumerable<AddonsDetails> GetAll() {
            var entities = db.Addons.ToList();
            return entities.Select(e => new AddonsDetails(e)).ToList();
        }

        public AddonsDetails GetById(int id) {
			var entity = db.Addons.FirstOrDefault(p => p.AddonId == id);
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
                Title = addon.Name,
                GameId = addon.GameId,
                ReleaseDate = returnDate,
                Description = addon.Description
            };

            db.Addons.Add(entity);
            db.SaveChanges();

            return addon;
        }

        public void Update(UpdateAddonBindingModel addon) {
            throw new NotImplementedException();
        }

        public void Delete(DeleteAddonBindingModel addon) {
            var entity = db.Addons.FirstOrDefault(a => a.AddonId == addon.AddonId);

            db.Addons.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = db.Addons.FirstOrDefault(a => a.AddonId == id);

            db.Addons.Remove(entity);
            db.SaveChanges();
        }
    }
}
