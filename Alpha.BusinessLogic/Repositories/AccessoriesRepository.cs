using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.DAL.Context;
using Alpha.Infrastructure.ViewModels;

namespace Alpha.BusinessLogic.Repositories {
    public class AccessoriesRepository : IAccessoriesRepository {
        private AlphaContext db = new AlphaContext();

        public IEnumerable<AccessoriesSummary> GetAll() {
			var entities = db.Accessories.ToList();
			return entities.Select(e => new AccessoriesSummary(e)).ToList();
		}

        public AccessoriesDetails GetById(int id) {
            var entity = db.Accessories.FirstOrDefault(p => p.AccessoryId == id);
            if(entity != null) {
                return new AccessoriesDetails(entity);
            }

            return null;
            
        }

        public int Add(AccessoriesDetails publisher) {
            return 0;
        }

        public void Update(AccessoriesDetails publisher) {
            throw new NotImplementedException();
        }

        public void Delete(AccessoriesDetails publisher) {
            throw new NotImplementedException();
        }

        public void DeleteById(int id) {
            throw new NotImplementedException();
        }
    }
}
