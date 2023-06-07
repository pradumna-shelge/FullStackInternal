using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.RepoPattren.interfaces
{
    public interface IGenricInterface<T>
    {
       IEnumerable<T> Get();
        void Add(T item);

        void Delete(T ob);

        void Update(T item,string id);



    }
}
