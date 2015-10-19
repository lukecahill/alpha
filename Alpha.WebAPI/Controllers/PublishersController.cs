using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using Alpha.Interfaces.Interfaces;

namespace Alpha.WebAPI.Controllers {
    public class PublishersController : ApiController {
        IPublisherRepository _rep;

        public PublishersController(IPublisherRepository rep) {
            _rep = rep;
        }

        // GET: api/Publishers
        public IEnumerable<PublisherSummary> GetPublishers() {
            return _rep.GetAll();
        }

        // GET: api/Publishers/5
        [ResponseType(typeof(PublisherDetails))]
        public IHttpActionResult GetPublisher(int id) {
            var publisher = _rep.GetById(id);
            if (publisher == null) {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/Publishers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublisher(int id, UpdatePublisherBindingModel publisher) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != publisher.PublisherId) {
                return BadRequest();
            }

            try {
                _rep.Update(publisher);
            } catch (DbUpdateConcurrencyException) {
                throw new Exception("Updated failed");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Publishers
        [ResponseType(typeof(CreatePublisherBindingModel))]
        public IHttpActionResult PostPublisher(CreatePublisherBindingModel publisher) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var saved = _rep.Add(publisher);
            return CreatedAtRoute("DefaultApi", new { id = saved }, saved);
        }

        // DELETE: api/Publishers/5
        [ResponseType(typeof(PublisherDetails))]
        public IHttpActionResult DeletePublisher(int id) {
            var publisher = _rep.GetById(id);
            if (publisher == null) {
                return NotFound();
            }

            var entity = new DeletePublisherBindingModel { PublisherId = id };
            _rep.Delete(entity);

            return Ok(publisher);
        }
    }
}