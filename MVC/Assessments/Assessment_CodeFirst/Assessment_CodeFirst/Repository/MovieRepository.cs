using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assessment_CodeFirst.Models;

namespace Assessment_CodeFirst.Repository
{
    public class MovieRepository<M> : IMovieRepository<M> where M : class
    {
        MovieContext db;
        DbSet<M> dbset;

        public MovieRepository()
        {
            db = new MovieContext();
            dbset = db.Set<M>();
        }
        public void Delete(object Id)
        {
            M getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }

        public IEnumerable<M> GetAll()
        {
            return dbset.ToList();
        }

        public M GetById(object id)
        {
            return dbset.Find(id);
        }

        public void Create(M obj)
        {
            dbset.Add(obj);

        }

        public void Update(M obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}