using System;
using System.ComponentModel.DataAnnotations;
using Movies.Api.Models;

namespace Movies.Api.Movies
{
    public class UpdateMovieRequest
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

        public Movie MapToMovie(Guid id)
        {
            return new Movie
            {
                Id = id,
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
