using System.ComponentModel.DataAnnotations;

namespace Alpha.Infrastructure.BindingModels {
    public class CreateAccessoriesBindingModels {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int GameId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class UpdateAccessoriesBindingModels {
        [Required]
        public int AccessoryId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int GameId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class DeleteAccessoriesBindingModels {
        [Required]
        public int AccessoryId { get; set; }
    }
}
