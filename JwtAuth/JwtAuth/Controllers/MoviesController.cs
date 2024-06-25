using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Extensions;
using Movies.Api.Identity;
using Movies.Api.Movies;
using Movies.Api.Services;

namespace Movies.Api.Controllers
{
    [Authorize]
    [Route("movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieRequest request)
        {
            var movie = request.MapToMovie();
            var result = _movieService.Create(movie);
            //return result.Match<IActionResult>(
            //    _ => CreatedAtAction(nameof(Get), new { idOrSlug = movie.Id }, movie.MapToResponse()),
            //    failed => BadRequest(failed.MapToResponse()));
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { idOrSlug = movie.Id }, movie);
            }
            return BadRequest(result.Error);
        }

        [AllowAnonymous]
        [HttpGet("{idOrSlug}")]
        public IActionResult Get([FromRoute] string idOrSlug)
        {
            var result = Guid.TryParse(idOrSlug, out var id)
                ? _movieService.Get(id)
                : _movieService.GetBySlug(idOrSlug);

            //return result.Match<IActionResult>(
            //    movie => Ok(movie.MapToResponse()),
            //    _ => NotFound());
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            var moviesResponse = movies.MapToResponse();
            return Ok(moviesResponse);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
        {
            var movie = request.MapToMovie(id);
            var result = _movieService.Update(movie);
            //return result.Match<IActionResult>(
            //    m=> Ok(m.MapToResponse()),
            //    _ => NotFound(),
            //    failed => BadRequest(failed.MapToResponse()));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return result.Error == "Not Found" ? NotFound() : BadRequest(result.Error);
        }

        // [Authorize(Policy = IdentityData.AdminUserPolicyName)] most basic way of making policy however some people prefer to validate based on a single calim without using a policy. Create a custom attribute(RequireClaimAttribute.cs) which validates claim 
        [Authorize] // first check Authorize and then Claim
        [RequiresClaim(IdentityData.AdminUserClaimName, "true")]
        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _movieService.DeleteById(id);
            //return result.Match<IActionResult>(
            //    _ => Ok(),
            //    _ => NotFound());
            if (result.IsSuccess)
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
