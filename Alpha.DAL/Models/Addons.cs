using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpha.DAL.Models {
    public class Addons : EntityBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddonId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        // Relationships
        [ForeignKey("GameId")]
        public virtual Games Game { get; set; }
        public int GameId { get; set; }

        public Addons() { }
    }
}
