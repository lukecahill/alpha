using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Alpha.Infrastructure.ViewModels;
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
        public IHttpActionResult PostAccessories(AccessoriesDetails accessories) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

			return null;
			// TODO : this
            //return CreatedAtRoute("DefaultApi", new { id = accessories.AccessoryId }, accessories);
        }

        // DELETE: api/Accessories/5
        [ResponseType(typeof(AccessoriesDetails))]
        public IHttpActionResult DeleteAccessories(int id) {
            var accessories = _rep.GetById(id);
            if (accessories == null) {
                return NotFound();
            }

            return Ok(accessories);
        }
    }
}