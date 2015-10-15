using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpha.DAL.Models {
    public class Games : EntityBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }

        // Relationships
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public virtual ICollection<Addons> Addons { get; set; }
        public virtual ICollection<Accessories> Accessories { get; set; }

        public Games() {
            this.Accessories = new HashSet<Accessories>();
            this.Addons = new HashSet<Addons>();
        }

        public Games(Games game) : this() {
            this.Title = game.Title;
            this.PublisherId = game.PublisherId;
            this.ReleaseDate = game.ReleaseDate;
            this.GameId = game.GameId;
        }
    }
}
