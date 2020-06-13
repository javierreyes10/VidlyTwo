using System.Collections.Generic;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface IMovieRepository
    {
        IEnumerable<Movie> Movies();
        Movie MovieById(int id);
        IEnumerable<Genre> Genres();
        void Add(Movie movie);
        void Save(Movie movie);
    }
}