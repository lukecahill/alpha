using Alpha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Alpha.Infrastructure.ViewModels {
    public class GameDetails {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }

		public string AddonName { get; set; }

		//public HashSet<Accessories> Accessories { get; set; }
		//public HashSet<Addons> Addons { get; set; }

		//public ReadOnlyCollection<Addons> AllAddons {
		//	get {
		//		return new List<Addons>(this.Addons).AsReadOnly();
		//	}
		//}
		
		public GameDetails(Games game) {
            this.Title = game.Title;
            this.Publisher = game.Publisher.Name;
            this.ReleaseDate = game.ReleaseDate;
        }
    }
}
