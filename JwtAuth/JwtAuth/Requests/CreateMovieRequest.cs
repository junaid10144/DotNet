using System.ComponentModel.DataAnnotations;
using Movies.Api.Models;

namespace Movies.Api.Movies
{
    public class CreateMovieRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Director { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Movie MapToMovie()
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = this.Title,
                Description = this.Description,
                Genre = this.Genre,
                Director = this.Director,
                ReleaseDate = this.ReleaseDate,
                Slug = this.Title.ToLower().Replace(" ", "-")
            };
        }
    }
}
