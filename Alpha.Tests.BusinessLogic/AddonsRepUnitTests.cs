using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alpha.BusinessLogic.Repositories;
using Alpha.Infrastructure.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Alpha.Tests.BusinessLogic {

	[TestClass]
	public class AddonsRepUnitTests {
		AddonsRepository _rep = new AddonsRepository();

		[TestMethod]
		public void PublisherGetFirst_Success() {
			AddonsDetails found = null;
			var time = DateTime.Parse("0001-01-01 00:00:00");
			var expected = new AddonsDetails { AddonName = "Map Pack 1", GameTitle = "Call of Duty 2", Publisher = "Activision", Description = "Play the game as it should have been released!", Price = 0.00M, AddonId = 1, ReleaseDate = time };
			Task.Run(async () => {
				found = await _rep.GetById(1);
				found.ReleaseDate = time;
			}).GetAwaiter().GetResult();

			Assert.AreEqual(expected, found);
		}

		[TestMethod]
		public void PublisherGetAll_Success() {
			var time = DateTime.Parse("0001-01-01 00:00:00");
			var expected = new AddonSummary { Title = "Map Pack 1", GameTitle = "Call of Duty 2", Publisher = "Activision", Price = 0.00M, AddonId = 1 };
			var all = _rep.GetAll();
			var found = all.First();

			Assert.AreEqual(expected, found);
		}
	}
}
