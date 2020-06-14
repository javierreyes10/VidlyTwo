using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VidlyTwo.Dto;
using VidlyTwo.Models;

namespace VidlyTwo.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        //GET api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return NotFound();

            return Ok(movie);

        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Today;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movieDto);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null) throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid) throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            var movieInDb = _context.Movies.Single(m => m.Id == id);
            if (movieInDb == null) throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
