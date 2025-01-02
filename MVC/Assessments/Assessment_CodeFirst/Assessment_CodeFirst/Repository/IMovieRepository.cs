using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment_CodeFirst.Models;

namespace Assessment_CodeFirst.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMoviesByYear(int year);

        IEnumerable<Movie> GetAll();

        Movie GetById(int id);
        void Create(Movie movie);
        void Edit(Movie movie);
    }
}
