using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alpha.BusinessLogic.Repositories;
using Alpha.Infrastructure.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Alpha.Tests.BusinessLogic {
    [TestClass]
    public class UnitTest1 {

		PublisherRepository _rep = new PublisherRepository();

		[TestMethod]
		public void PublisherGetAll_Success() {
			var item = _rep.GetAll();

			var expected = new List<PublisherSummary>() {
				new PublisherSummary { Name = "Activision", Location = "USA" },
				new PublisherSummary { Name = "SEGA", Location = "USA" },
				new PublisherSummary { Name = "Sierra", Location = "France" }
			};
		}

		[TestMethod]
		public void PublisherGetById_Success() {
			Task.Run(async () => {
				var item = await _rep.GetById(1);

				var expected = new PublisherDetails {
					Name = "Activistion",
					Location = "USA"
				};

				item.GameList = null;

				Assert.AreEqual(expected, item);
			}).GetAwaiter().GetResult();
		}

		[TestMethod] 
		public void PublisherCreate_Success() {
			var item = _rep.Add(new Infrastructure.BindingModels.CreatePublisherBindingModel {
				Name = "Test",
				Location = "UK"
			});

			var expected = new Infrastructure.BindingModels.CreatePublisherBindingModel {
				Name = "Test",
				Location = "UK"
			};

			Assert.AreEqual(expected, item);
		}
	}
}
