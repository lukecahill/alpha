using System.ComponentModel.DataAnnotations;

namespace Alpha.DAL.Models {
    public class Accessories : Extras {
        
        [MaxLength(255)]
        public string Type { get; set; }

        public Accessories() { }
    }
}
