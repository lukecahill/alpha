using Alpha.DAL.Context;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using Alpha.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.BusinessLogic.Repositories {
    public class PublisherRepository : IPublisherRepository {

        private AlphaContext db = new AlphaContext();

        public IEnumerable<PublisherSummary> GetAll() {
            var entities = db.Publishers.ToList().Where(p => p.IsDeleted == false);
			return entities.Select(e => new PublisherSummary(e)).ToList();
        }

        public PublisherDetails GetById(int id) {
			var entity = db.Publishers.FirstOrDefault(p => p.PublisherId == 1);
            if(entity != null) {
			    return new PublisherDetails(entity);
            }

            return null;
		}

        public CreatePublisherBindingModel Add(CreatePublisherBindingModel publisher) {
            var entity = new DAL.Models.Publisher {
                Name = publisher.Name,
                Location = publisher.Location
            };

            db.Publishers.Add(entity);
            db.SaveChanges();
            return publisher;
        }

        public void Update(PublisherDetails publisher) {
            throw new NotImplementedException();
        }

        public void Delete(PublisherDetails publisher) {
            throw new NotImplementedException();
        }

        public void DeleteById(int id) {
            throw new NotImplementedException();
        }
    }
}
