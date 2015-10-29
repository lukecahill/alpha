using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpha.DAL.Models {
    public class Extras : EntityBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExtraId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        // Decimal due to floating point calculations
        public decimal Price { get; set; }

        // Relationships
        [ForeignKey("GameId")]
        public virtual Games Game { get; set; }
        public int GameId { get; set; }

        public Extras() { }
    }
}
