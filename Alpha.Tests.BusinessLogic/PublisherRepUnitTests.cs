using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alpha.BusinessLogic.Repositories;
using Alpha.Infrastructure.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Alpha.Tests.BusinessLogic {
	[TestClass]
	public class PublisherRepUnitTests {

		PublisherRepository _rep = new PublisherRepository();

		[TestMethod]
		public void PublisherGetFirst_Success() {
			PublisherDetails found = null;
			var expected = new PublisherDetails { Name = "Activision", GameList = null, Location = "USA" };
			Task.Run(async () => {
				found = await _rep.GetById(1);
				found.GameList = null;
			}).GetAwaiter().GetResult();

			Assert.AreEqual(expected, found);
		}

		[TestMethod]
		public void PublisherGetAll_Success() {
			var expected = new PublisherSummary { PublisherId = 1, Location = "USA", Name = "Activision" };
			var all = _rep.GetAll();
			var found = all.First();

			Assert.AreEqual(expected, found);
		}
	}
}
