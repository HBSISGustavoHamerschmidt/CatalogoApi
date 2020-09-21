using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoApi.Models;
using Web.Api.Hbsis.Models.Context;

namespace CatalogoApi.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            return _context.Categoria.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> GetSingleCategory(int id)
        {
            var category = _context.Categoria.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPost]
        public ActionResult PostCategoria([FromBody] Categoria category)
        {
            if (_context.Categoria.FirstOrDefault(p => p.CategoriaId == category.CategoriaId) != null)
                return BadRequest(
                    "Identificador da categoria é adicionado automaticamente e não deve ser passado como parâmetro.");


            _context.Categoria.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = category.CategoriaId }, category);
        }

        [HttpPut("{id}")]
        public ActionResult PutCategoria(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Categoria> DeleteCategoria(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
                return NotFound();

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}
