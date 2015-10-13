using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infratructure.BindingModels;
using Alpha.Interfaces.Interfaces;

namespace Alpha.WebAPI.Controllers {
    public class GamesController : ApiController {
        IGamesRepository _rep;

        public GamesController(IGamesRepository rep) {
            _rep = rep;
        }

        // GET: api/Games
        public IEnumerable<GameSummary> GetGames() {
            return _rep.GetAll();
        }

        // GET: api/Games/5
        [ResponseType(typeof(GameDetails))]
        public IHttpActionResult GetGames(int id) {
            var games = _rep.GetById(id);
            if (games == null) {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGames(int id, GameDetails games) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //if (id != games.GameId) {
            //    return BadRequest();
            //}

            try {
            } catch (DbUpdateConcurrencyException) {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(GameDetails))]
        public IHttpActionResult PostGames(CreateGameBindingModel games) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _rep.Add(games);

            return CreatedAtRoute("DefaultApi", new { id = games }, games);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(GameDetails))]
        public IHttpActionResult DeleteGames(int id) {
            var games = _rep.GetById(id);
            if (games == null) {
                return NotFound();
            }
            return Ok(games);
        }
    }
}