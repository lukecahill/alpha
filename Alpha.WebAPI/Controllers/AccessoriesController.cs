using Alpha.Infrastructure.BindingModels;
using Alpha.Infrastructure.ViewModels;
using Alpha.Interfaces.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Alpha.WebAPI.Controllers {
    public class AccessoriesController : ApiController {
        IAccessoriesRepository _rep;

        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        public IHttpActionResult PutAccessories(UpdateAccessoriesBindingModels accessories) {
            if (!ModelState.IsValid) {
                _log.Info($"");
                return BadRequest(ModelState);
            }

            //if (id != accessories.AccessoryId) {
            //    return BadRequest();
            //}

            try {
                _rep.Update(accessories);
                _log.Info($"Accessory with the ID {accessories.AccessoryId} has been updated.");
            } catch (DbUpdateConcurrencyException db) {
                _log.Error($"Error updating accessory ID: {accessories.AccessoryId}.");
                throw new System.Exception("Update failed");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Accessories
        [ResponseType(typeof(AccessoriesDetails))]
        public IHttpActionResult PostAccessories(CreateAccessoriesBindingModels accessories) {
            if (!ModelState.IsValid) {
                _log.Error($"Could not create the new accessory name {accessories.Name}");
                return BadRequest(ModelState);
            }

            _log.Info($"Accessory {accessories.Name} created!");
            _rep.Add(accessories);
            
			// TODO : this
            return CreatedAtRoute("DefaultApi", new { id = accessories }, accessories);
        }

        // DELETE: api/Accessories/5
        [ResponseType(typeof(AccessoriesDetails))]
        public IHttpActionResult DeleteAccessories(int id) {
            var accessories = _rep.GetById(id);
            if (accessories == null) {
                _log.Error($"Could not find the accessory with the ID {id}");
                return NotFound();
            }

            var entity = new DeleteAccessoriesBindingModels { AccessoryId = id };
            _log.Info($"Accessory with the ID {id} was deleted!");
            _rep.Delete(entity);
            return Ok(accessories);
        }
    }
}