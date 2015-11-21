using Alpha.DAL.Context;
using Alpha.Infrastructure.BindingModels;
using Alpha.Infrastructure.ViewModels;
using Alpha.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Alpha.BusinessLogic.Repositories {
    public class AccessoriesRepository : IDisposable, IAccessoriesRepository {
        private readonly AlphaContext db = new AlphaContext();

        public IEnumerable<AccessoriesSummary> GetAll() {
			var entities = db.Accessories
                .Include(g => g.Game)
                .ToList()
                .Where(a => a.IsDeleted == false);

			return entities.Select(e => new AccessoriesSummary(e)).ToList();
		}

        public async Task<AccessoriesDetails> GetById(int id) {
            var entity = await db.Accessories
                .Include(g => g.Game).Where(g => g.IsDeleted == false)
                .Include(g => g.Game.Publisher).Where(g => g.IsDeleted == false)
                .Where(a => a.IsDeleted == false)
                .FirstOrDefaultAsync(a => a.ExtraId == id);

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
                GameId = accessory.GameId,
                Price = accessory.Price
            };

            db.Accessories.Add(entity);
            db.SaveChanges();
            return accessory;
        }

        public void Update(UpdateAccessoriesBindingModels accessory) {
            var entity = db.Accessories.FirstOrDefault(a => a.ExtraId == accessory.AccessoryId);

            entity.Name = accessory.Name;
            entity.Description = accessory.Description;
            entity.GameId = accessory.GameId;
            entity.Type = accessory.Type;
            entity.Price = accessory.Price;

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
         }

        public void Delete(DeleteAccessoriesBindingModels accessory) {
            var entity = db.Accessories.FirstOrDefault(a => a.ExtraId == accessory.AccessoryId);

            db.Accessories.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = db.Accessories.FirstOrDefault(a => a.ExtraId == id);

            db.Accessories.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
