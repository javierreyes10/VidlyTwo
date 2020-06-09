using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface IMovieService
    {
    List<Movie> Movies();
    }

    public class MovieService : IMovieService
    {
        private List<Movie> _movies;

        public MovieService()
        {
            _movies = new List<Movie>
            {
                new Movie() {Id = 1, Name = "Avengers"},
                new Movie() {Id = 2, Name = "Star Wars"}
            };
        }
        public List<Movie> Movies()
        {
            return _movies;
        }
    }
}
