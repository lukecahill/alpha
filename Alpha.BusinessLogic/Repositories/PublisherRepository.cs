using Alpha.DAL.Context;
using Alpha.Infrastructure.BindingModels;
using Alpha.Infrastructure.ViewModels;
using Alpha.Interfaces.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alpha.BusinessLogic.Repositories {
    public class PublisherRepository : IDisposable, IPublisherRepository {

        private readonly AlphaContext db = new AlphaContext();

        public IEnumerable<PublisherSummary> GetAll() {
            //         var entities = await db.Publishers
            //             .Where(p => p.IsDeleted == false)
            //             .ToListAsync();

            //return entities.Select(e => new PublisherSummary(e)).ToList();

            var entities = db.Publishers
                .ToList()
                .Where(p => p.IsDeleted == false);

			return entities.Select(e => new PublisherSummary(e)).ToList();
        }

        public async Task<PublisherDetails> GetById(int id) {
			var entity = await db.Publishers
                .Include(g => g.Games).Where(g => g.IsDeleted == false)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.PublisherId == id);

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

        public void Update(UpdatePublisherBindingModel publisher) {

            var entity = db.Publishers.FirstOrDefault(g => g.PublisherId == publisher.PublisherId);
            
            entity.Name = publisher.Name;
            entity.Location = publisher.Location;

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(DeletePublisherBindingModel publisher) {
            var entity = db.Publishers.FirstOrDefault(p => p.PublisherId == publisher.PublisherId);

            db.Publishers.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = db.Publishers.FirstOrDefault(p => p.PublisherId == id);

            db.Publishers.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
