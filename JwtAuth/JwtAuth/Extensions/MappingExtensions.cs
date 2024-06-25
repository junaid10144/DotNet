using System.Collections.Generic;
using Movies.Api.Models;

namespace Movies.Api.Extensions
{
    public static class MappingExtensions
    {
        public static IEnumerable<MovieResponse> MapToResponse(this IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {
                yield return new MovieResponse
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Genre = movie.Genre,
                    Director = movie.Director,
                    ReleaseDate = movie.ReleaseDate,
                    Slug = movie.Slug
                };
            }
        }
    }

    public class MovieResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Slug { get; set; }
    }
}
