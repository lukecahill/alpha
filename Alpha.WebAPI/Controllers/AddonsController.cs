using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Alpha.Infrastructure.ViewModels;
using Alpha.Interfaces.Interfaces;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.WebAPI.Controllers {
    public class AddonsController : ApiController {
        IAddonsRepository _rep;

        public AddonsController(IAddonsRepository rep) {
            _rep = rep;
        }

        // GET: api/Addons
        public IEnumerable<AddonsDetails> GetAddons() {
            return _rep.GetAll();
        }

        // GET: api/Addons/5
        [ResponseType(typeof(AddonsDetails))]
        public IHttpActionResult GetAddons(int id) {
            var addons = _rep.GetById(id);
            if (addons == null) {
                return NotFound();
            }

            return Ok(addons);
        }

        // PUT: api/Addons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddons(int id, UpdateAddonBindingModel addons) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != addons.AddonId) {
                return BadRequest();
            }

            try {
                _rep.Update(addons);
            } catch (DbUpdateConcurrencyException) {
                throw new System.Exception("Update failed");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addons
        [ResponseType(typeof(AddonsDetails))]
        public IHttpActionResult PostAddons(CreateAddonBindingModel addons) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _rep.Add(addons);
            return CreatedAtRoute("DefaultApi", new { id = addons }, addons);
        }

        // DELETE: api/Addons/5
        [ResponseType(typeof(AddonsDetails))]
        public IHttpActionResult DeleteAddons(int id) {
            var addons = _rep.GetById(id);
            if (addons == null) {
                return NotFound();
            }

            var entity = new DeleteAddonBindingModel { AddonId = id };
            _rep.Delete(entity);

            return Ok(addons);
        }
    }
}