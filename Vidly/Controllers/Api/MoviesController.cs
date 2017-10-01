using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //get all movies
        public IEnumerable<MoviesDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie,MoviesDTO>);
        }

        //get single movie by id
        public IHttpActionResult GetMovie(int id) {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                NotFound();

            return Ok(Mapper.Map<Movie, MoviesDTO>(movie));
        }

        //add movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDTO moviesDTO) {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDTO, Movie>(moviesDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            moviesDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDTO);
        }

        //update movie
        [HttpPut]
        public void UpdateMovie(int id, MoviesDTO moviesDTO) {
            var movieToBeUpdated = _context.Movies.Single(m => m.Id == id);

            if (movieToBeUpdated == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(moviesDTO, movieToBeUpdated);
            _context.SaveChanges();
        }
        //delete movie
        [HttpDelete]
        public void Delete(int id) {
            var movieToBeDeleted = _context.Movies.Single(m => m.Id == id);

            if (movieToBeDeleted == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieToBeDeleted);
            _context.SaveChanges();
            
        }

    }
}