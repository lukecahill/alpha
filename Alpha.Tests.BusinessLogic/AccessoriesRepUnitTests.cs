using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alpha.BusinessLogic.Repositories;
using Alpha.Infrastructure.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Alpha.Tests.BusinessLogic {

	[TestClass]
	public class AccessoriesRepUnitTests {
		AccessoriesRepository _rep = new AccessoriesRepository();

		[TestMethod]
		public void PublisherGetFirst_Success() {
			AccessoriesDetails found = null;
			var expected = new AccessoriesDetails { AccessoryId = 1, Name = "Gun", Publisher = "Activision", Description = "It is not real.", Type = "WWII themed gun.", GameTitle = "Call of Duty 2", Price = 0.00M };
			Task.Run(async () => {
				found = await _rep.GetById(1);
			}).GetAwaiter().GetResult();

			Assert.AreEqual(expected, found);
		}

		[TestMethod]
		public void PublisherGetAll_Success() {
			var expected = new AccessoriesSummary { AccessoryId = 1, Name = "Gun", GameTitle = "Call of Duty 2", Price = 0.00M };
			var all = _rep.GetAll();
			var found = all.First();

			Assert.AreEqual(expected, found);
		}
	}
}
