using System;
using System.Collections.Generic;
using Movies.Api.Models;

namespace Movies.Api.Services
{
    public interface IMovieService
    {
        Result<Movie> Create(Movie movie);
        Result<Movie> Get(Guid id);
        Result<Movie> GetBySlug(string slug);
        IEnumerable<Movie> GetAll();
        Result<Movie> Update(Movie movie);
        Result DeleteById(Guid id);
    }
}
