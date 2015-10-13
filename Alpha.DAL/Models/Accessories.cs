using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpha.DAL.Models {
    public class Accessories : EntityBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessoryId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        // Relationships
        [ForeignKey("GameId")]
        public virtual Games Game { get; set; }
        public int GameId { get; set; }

        public Accessories() { }
    }
}
