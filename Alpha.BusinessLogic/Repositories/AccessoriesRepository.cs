using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Alpha.Interfaces.Interfaces;
using Alpha.DAL.Context;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.BusinessLogic.Repositories {
    public class AccessoriesRepository : IAccessoriesRepository {
        private AlphaContext db = new AlphaContext();

        public IEnumerable<AccessoriesSummary> GetAll() {
			var entities = db.Accessories
                .Include(g => g.Game)
                .Include(a => a.Game.Publisher)
                .ToList()
                .Where(a => a.IsDeleted == false);

			return entities.Select(e => new AccessoriesSummary(e)).ToList();
		}

        public AccessoriesDetails GetById(int id) {
            var entity = db.Accessories
                .Include(g => g.Game)
                .Include(g => g.Game.Publisher)
                .FirstOrDefault(p => p.AccessoryId == id);
            if(entity != null) {
                return new AccessoriesDetails(entity);
            }

            return null;
        }

        public CreateAccessoriesBindingModels Add(CreateAccessoriesBindingModels accessory) {
            var entity = new DAL.Models.Accessories {
                Name = accessory.Name,
                Type = accessory.Type,
                Description = accessory.Description,
                GameId = accessory.GameId
            };

            db.Accessories.Add(entity);
            db.SaveChanges();
            return accessory;
        }

        public void Update(UpdateAccessoriesBindingModels accessory) {
            throw new NotImplementedException();
        }

        public void Delete(DeleteAccessoriesBindingModels accessory) {
            var entity = db.Accessories.FirstOrDefault(a => a.AccessoryId == accessory.AccessoryId);

            db.Accessories.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = db.Accessories.FirstOrDefault(a => a.AccessoryId == id);

            db.Accessories.Remove(entity);
            db.SaveChanges();
        }
    }
}
