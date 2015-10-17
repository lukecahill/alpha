using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infratructure.BindingModels;
using Alpha.Interfaces.Interfaces;

namespace Alpha.WebAPI.Controllers {
    public class AccessoriesController : ApiController {
        IAccessoriesRepository _rep;

        public AccessoriesController(IAccessoriesRepository rep) {
            _rep = rep;
        }

        // GET: api/Accessories
        public IEnumerable<AccessoriesSummary> GetAccessories() {
            return _rep.GetAll();
        }

        // GET: api/Accessories/5
        [ResponseType(typeof(AccessoriesDetails))]
        public IHttpActionResult GetAccessories(int id) {
            var accessories = _rep.GetById(id);
            if (accessories == null) {
                return NotFound();
            }

            return Ok(accessories);
        }

        // PUT: api/Accessories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccessories(int id, AccessoriesDetails accessories) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //if (id != accessories.AccessoryId) {
            //    return BadRequest();
            //}

            try {
            } catch (DbUpdateConcurrencyException) {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Accessories
        [ResponseType(typeof(AccessoriesDetails))]
        public IHttpActionResult PostAccessories(CreateAccessoriesBindingModels accessories) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _rep.Add(accessories);
            
			// TODO : this
            return CreatedAtRoute("DefaultApi", new { id = accessories }, accessories);
        }

        // DELETE: api/Accessories/5
        [ResponseType(typeof(AccessoriesDetails))]
        public IHttpActionResult DeleteAccessories(int id) {
            var accessories = _rep.GetById(id);
            if (accessories == null) {
                return NotFound();
            }

            var entity = new DeleteAccessoriesBindingModels { AccessoryId = id };

            _rep.Delete(entity);
            return Ok(accessories);
        }
    }
}