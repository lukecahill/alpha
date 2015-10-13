using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpha.DAL.Models {
    /// <summary>
    /// Publisher class model (e.g. Activision, Blizzard etc).
    /// </summary>
    public class Publisher : EntityBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        // Relationships
        public virtual ICollection<Games> Games { get; set; }

        public Publisher() {
            this.Games = new HashSet<Games>();
        }

        public Publisher(Publisher publisher) : this() {
            this.Name = publisher.Name;
            this.Location = publisher.Location;
        }
    }
}
