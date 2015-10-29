using System;
using System.ComponentModel.DataAnnotations;

namespace Alpha.DAL.Models {
    public class Addons : Extras {

        public DateTime ReleaseDate { get; set; }

        public Addons() { }
    }
}
