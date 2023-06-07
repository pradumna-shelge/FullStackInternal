using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.RepoPattren.Classes
{
    public class Genric<T> : IGenricInterface<T> where T : class
    {
        private readonly DonationSystemContext _contex;
            private readonly DbSet<T> _dbset;

        public Genric(DonationSystemContext context)
        {
            _contex = context;
            _dbset = _contex.Set<T>();

        }

        public void Add(T item)
        {
          _dbset.Add(item);
           _contex.SaveChanges();

        }

        public void Delete(T ob)
        {
            _dbset.Remove(ob);
            _contex.SaveChanges();
        }

        public  IEnumerable<T> Get()
        {
            return  _dbset;
        }

        public void Update(T item, string id)
        {
            
            throw new NotImplementedException();
        }
    }
}
