using System;
using System.Collections.Generic;
using System.Linq;
using Movies.Api.Models;

namespace Movies.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();

        public Result<Movie> Create(Movie movie)
        {
            if (_movies.Any(m => m.Title.Equals(movie.Title, StringComparison.OrdinalIgnoreCase)))
            {
                return Result<Movie>.Failure("A movie with the same title already exists.");
            }

            _movies.Add(movie);
            return Result<Movie>.Success(movie);
        }

        public Result<Movie> Get(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return Result<Movie>.Failure("Movie not found.");
            }

            return Result<Movie>.Success(movie);
        }

        public Result<Movie> GetBySlug(string slug)
        {
            var movie = _movies.FirstOrDefault(m => m.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
            if (movie == null)
            {
                return Result<Movie>.Failure("Movie not found.");
            }

            return Result<Movie>.Success(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public Result<Movie> Update(Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie == null)
            {
                return Result<Movie>.Failure("Movie not found.");
            }

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.Genre = movie.Genre;
            existingMovie.Director = movie.Director;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Slug = movie.Slug;

            return Result<Movie>.Success(existingMovie);
        }

        public Result DeleteById(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return Result.Failure("Movie not found.");
            }

            _movies.Remove(movie);
            return Result.Success();
        }
    }
}
