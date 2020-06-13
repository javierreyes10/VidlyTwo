using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ApplicationDbContext _context;

        public MovieRepository()
        {
            _context = new ApplicationDbContext();
        }
        
        public IEnumerable<Movie> Movies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }

        public Movie MovieById(int id)
        {
            return _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Genre> Genres()
        {
            return _context.Genres;
        }

        public void Add(Movie movie)
        {
            movie.DateAdded = DateTime.Today;
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Save(Movie movie)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            _context.SaveChanges();
        }
    }
}
