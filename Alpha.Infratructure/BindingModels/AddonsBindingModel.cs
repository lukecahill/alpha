using System.ComponentModel.DataAnnotations;

namespace Alpha.Infrastructure.BindingModels {
    public class CreateAddonBindingModel {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        public string ReleaseDate { get; set; }

        [Required]
        public int GameId { get; set; }
    }

    public class UpdateAddonBindingModel {
        [Required]
        public int AddonId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        public string ReleaseDate { get; set; }

        [Required]
        public int GameId { get; set; }
    }

    public class DeleteAddonBindingModel {
        [Required]
        public int AddonId { get; set; }
    }
}
