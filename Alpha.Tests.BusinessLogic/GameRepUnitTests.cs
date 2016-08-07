using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alpha.BusinessLogic.Repositories;
using Alpha.Infrastructure.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Alpha.Tests.BusinessLogic {

	[TestClass]
	public class GameRepUnitTests {
		 GamesRepository _rep = new GamesRepository();

		[TestMethod]
		public void GameGetFirst_Success() {
			GameDetails found = null;
			var time = DateTime.Parse("21/11/2015 20:06:04");
			var expected = new GameDetails { Title = "Call of Duty 2", Publisher = "Activision", AccessoryList = null, AddonList = null, PictureLink = null, Price = 14.99M, ReleaseDate = time };

			Task.Run(async () => {
				found = await _rep.GetById(1);
				found.AccessoryList = null;
				found.AddonList = null;
			}).GetAwaiter().GetResult();

			Assert.AreEqual(expected, found);
		}

		[TestMethod]
		public void GamesGetAll_Success() {
			var time = DateTime.Parse("0001-01-01 00:00:00");
			var expected = new GameSummary { GameId = 1, Title = "Call of Duty 2", Price = 14.99M, ReleaseDate = time, PublisherName = "Activision" };
			var all = _rep.GetAll();
			var found = all.First();
			found.ReleaseDate = time;

			Assert.AreEqual(expected, found);
		}
	}
}
