using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CatalogoApi.Repo
{
    public interface ICatalogoRepo<T>
    {
        bool SaveChanges();
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}