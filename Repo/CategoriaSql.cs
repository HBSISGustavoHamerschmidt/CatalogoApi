using System.Collections.Generic;
using System.Linq;
using CatalogoApi.Models;
/*using Microsoft.EntityFrameworkCore;
using Web.Api.Hbsis.Models.Context;

namespace CatalogoApi.Repo
{
    
    public class CategoriaSql : ICatalogoRepo<Categoria>
    {
        private readonly AppDbContext _context;
        public CategoriaSql(AppDbContext context) => _context = context;

        public bool SaveChanges() => _context.SaveChanges() >= 0;

        public IEnumerable<Categoria> GetAll() => _context.Categoria.AsNoTracking().ToList();

        public Categoria GetById(int id) => _context.Categoria.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

        public void Create(Categoria obj) => _context.Categoria.Add(obj);

        public void Update(Categoria obj) => _context.Entry(obj).State = EntityState.Modified;

        public void Delete(Categoria obj) => _context.Categoria.Remove(obj);
    }
}


Tentei implementar mas não consegui a tempo
*/