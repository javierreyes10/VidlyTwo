using System.Collections.Generic;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface IMovieRepository
    {
        IEnumerable<Movie> Movies();
        Movie MovieById(int id);
    }
}