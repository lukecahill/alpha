using Alpha.Infrastructure.BindingModels;
using Alpha.Infrastructure.ViewModels;
using Alpha.Interfaces.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Alpha.WebAPI.Controllers {
    public class PublishersController : ApiController {
        IPublisherRepository _rep;

        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PublishersController(IPublisherRepository rep) {
            _rep = rep;
        }

        // GET: api/Publishers
        public IEnumerable<PublisherSummary> GetPublishers() {
            return _rep.GetAll();
        }

        // GET: api/Publishers/5
        [ResponseType(typeof(PublisherDetails))]
        public async Task<IHttpActionResult> GetPublisher(int id) {
            var publisher = await _rep.GetById(id);
            if (publisher == null) {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/Publishers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublisher(UpdatePublisherBindingModel publisher) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //if (id != publisher.PublisherId) {
            //    return BadRequest();
            //}

            try {
                _rep.Update(publisher);
                _log.Info($"Publisher with the ID {publisher.PublisherId} has been updated!");
            } catch (DbUpdateConcurrencyException) {
                _log.Error($"Update failed for publisher ID {publisher.PublisherId}");
                throw new Exception("Updated failed");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Publishers
        [ResponseType(typeof(CreatePublisherBindingModel))]
        public IHttpActionResult PostPublisher(CreatePublisherBindingModel publisher) {
            if (!ModelState.IsValid) {
                _log.Error($"Creation of publisher '{publisher.Name}' failed!");
                return BadRequest(ModelState);
            }

            var saved = _rep.Add(publisher);
            _log.Info($"Publisher created with the name '{publisher.Name}'");
            return CreatedAtRoute("DefaultApi", new { id = saved }, saved);
        }

        // DELETE: api/Publishers/5
        [ResponseType(typeof(PublisherDetails))]
        public IHttpActionResult DeletePublisher(int id) {
            var publisher = _rep.GetById(id);
            if (publisher == null) {
                _log.Error($"Deleteion of {id} failed due to not being found. Was this already deleted?");
                return NotFound();
            }

            var entity = new DeletePublisherBindingModel { PublisherId = id };
            _log.Info($"Publisher with the ID {entity.PublisherId} was deleted.");
            _rep.Delete(entity);
            return Ok(publisher);
        }
    }
}