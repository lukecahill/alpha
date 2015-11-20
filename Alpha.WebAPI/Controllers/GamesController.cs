using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infrastructure.BindingModels;
using Alpha.Interfaces.Interfaces;
using log4net;
using System.Threading.Tasks;

namespace Alpha.WebAPI.Controllers {
    public class GamesController : ApiController {
        IGamesRepository _rep;

        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GamesController(IGamesRepository rep) {
            _rep = rep;
        }

        // GET: api/Games
        public IEnumerable<GameSummary> GetGames() {
            return _rep.GetAll();
        }

        // GET: api/Games/5
        [ResponseType(typeof(GameDetails))]
        public async Task<IHttpActionResult> GetGames(int id) {
            var games = await _rep.GetById(id);
            if (games == null) {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGames(UpdateGameBindingModel games) {
            if (!ModelState.IsValid) {
                _log.Error($"Update for {games.GameId} failed!");
                return BadRequest(ModelState);
            }

            try {
                _rep.Update(games);
                _log.Info($"Update for {games.GameId} success!");
            } catch (DbUpdateConcurrencyException db) {
                _log.Error($"Update for {games.GameId} failed! Error message: {db.Message}");
                throw new System.Exception("Update failed!");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(GameDetails))]
        public IHttpActionResult PostGames(CreateGameBindingModel games) {
            if (!ModelState.IsValid) {
                _log.Error($"Creation of {games.Title} failed!");
                return BadRequest(ModelState);
            }

            _rep.Add(games);
            _log.Info($"Creation of {games.Title} was successful");
            return CreatedAtRoute("DefaultApi", new { id = games }, games);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(GameDetails))]
        public IHttpActionResult DeleteGames(int id) {
            var games = _rep.GetById(id);
            if (games == null) {
                _log.Error($"The ID {id} was not found!");
                return NotFound();
            }

            var entity = new DeleteGameBindingModel { GameId = id };
            _log.Info($"The game with the id {id} has been deleted.");
            _rep.Delete(entity);

            return Ok(games);
        }
    }
}