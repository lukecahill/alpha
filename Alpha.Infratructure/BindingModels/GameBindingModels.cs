using System.ComponentModel.DataAnnotations;

namespace Alpha.Infrastructure.BindingModels {
    public class CreateGameBindingModel {
        [Required, MaxLength(255)]
        public string Title { get; set; }

        public string ReleaseDate { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public string PictureLink { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class UpdateGameBindingModel {
        [Required]
        public int GameId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public string ReleaseDate { get; set; }

        public string PictureLink { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class DeleteGameBindingModel {
        [Required]
        public int GameId { get; set; }
    }
}
