using System.ComponentModel.DataAnnotations;

namespace Alpha.Infrastructure.BindingModels {
    public class CreatePublisherBindingModel {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }
    }
    
    public class UpdatePublisherBindingModel {
        [Required]
        public int PublisherId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }
    }
    
    public class DeletePublisherBindingModel {
        [Required]
        public int PublisherId { get; set; }
    }
}
