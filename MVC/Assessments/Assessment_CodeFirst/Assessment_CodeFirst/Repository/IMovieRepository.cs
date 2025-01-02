using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_CodeFirst.Repository
{
    public interface IMovieRepository<M> where M :class
    {
        IEnumerable<M> GetAll();
        M GetById(object id);  
        void Create(M obj);
        void Update(M obj);
        void Save();
    }
}
