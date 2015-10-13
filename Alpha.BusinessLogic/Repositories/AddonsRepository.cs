using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Interfaces.Interfaces;
using Alpha.DAL.Context;
using Alpha.Infrastructure.ViewModels;

namespace Alpha.BusinessLogic.Repositories {
    public class AddonsRepository : IAddonsRepository {
        private AlphaContext db = new AlphaContext();

        public IEnumerable<AddonsDetails> GetAll() {
            var entities = db.Addons.ToList();
            return entities.Select(e => new AddonsDetails(e)).ToList();
            //return db.Addons;
        }

        public AddonsDetails GetById(int id) {
			var entity = db.Addons.FirstOrDefault(p => p.AddonId == id);
            if(entity != null) {
                return new AddonsDetails(entity);
            }

            return null;
			// TODO: I think this is how it is done anyway... It is!
        }

        public int Add(AddonsDetails publisher) {
            return 0;
        }

        public void Update(AddonsDetails publisher) {
            throw new NotImplementedException();
        }

        public void Delete(AddonsDetails publisher) {
            throw new NotImplementedException();
        }

        public void DeleteById(int id) {
            throw new NotImplementedException();
        }
    }
}
