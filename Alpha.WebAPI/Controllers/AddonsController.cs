using Alpha.Infrastructure.BindingModels;
using Alpha.Infrastructure.ViewModels;
using Alpha.Interfaces.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace Alpha.WebAPI.Controllers {
    public class AddonsController : ApiController {
        IAddonsRepository _rep;

        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AddonsController(IAddonsRepository rep) {
            _rep = rep;
        }

        // GET: api/Addons
        public IEnumerable<AddonSummary> GetAddons() {
            return _rep.GetAll();
        }

        // GET: api/Addons/5
        [ResponseType(typeof(AddonsDetails))]
        public async Task<IHttpActionResult> GetAddons(int id) {
            var addons = await _rep.GetById(id);
            if (addons == null) {
                return NotFound();
            }

            return Ok(addons);
        }

        // PUT: api/Addons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddons(UpdateAddonBindingModel addons) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //if (id != addons.AddonId) {
            //    return BadRequest();
            //}

            try {
                _rep.Update(addons);
                _log.Info($"Addon with ID {addons.AddonId} has been updated.");
            } catch (DbUpdateConcurrencyException db) {
                _log.Error($"Error updating {addons.AddonId}. Error thrown: {db.Message}");
                throw new System.Exception("Update failed");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addons
        [ResponseType(typeof(AddonsDetails))]
        public IHttpActionResult PostAddons(CreateAddonBindingModel addons) {
            if (!ModelState.IsValid) {
                _log.Error($"Could not create addon with the name {addons.Name}. Invalid request!");
                return BadRequest(ModelState);
            }

            _rep.Add(addons);
            _log.Info($"Created addon with the name {addons.Name}");
            return CreatedAtRoute("DefaultApi", new { id = addons }, addons);
        }

        // DELETE: api/Addons/5
        [ResponseType(typeof(AddonsDetails))]
        public IHttpActionResult DeleteAddons(int id) {
            var addons = _rep.GetById(id);
            if (addons == null) {
                _log.Error($"Could not find the addon with the id {id}!");
                return NotFound();
            }

            var entity = new DeleteAddonBindingModel { AddonId = id };
            _log.Info($"Addon with the ID {id} has been deleted!");
            _rep.Delete(entity);

            return Ok(addons);
        }
    }
}