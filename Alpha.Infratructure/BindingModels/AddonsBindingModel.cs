using System;
using System.ComponentModel.DataAnnotations;

namespace Alpha.Infratructure.BindingModels {
    public class CreateAddonBindingModel {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        public DateTime ReleaseDate { get; set; }
    }

    public class UpdateAddonBindingModel {
        [Required]
        public int AddonId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        public DateTime ReleaseDate { get; set; }
    }

    public class DeleteAddonBindingModel {
        [Required]
        public int AddonId { get; set; }
    }
}
