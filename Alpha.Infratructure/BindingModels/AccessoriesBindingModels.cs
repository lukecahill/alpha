using System.ComponentModel.DataAnnotations;

namespace Alpha.Infratructure.BindingModels {
    public class CreateAccessoriesBindingModels {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Type { get; set; }
    }

    public class UpdateAccessoriesBindingModels {
        [Required]
        public int AccessoryId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Type { get; set; }
    }

    public class DeleteAccessoriesBindingModels {
        [Required]
        public int AccessoryId { get; set; }
    }
}
