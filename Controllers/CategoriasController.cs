using System;
using CatalogoApi.Models;
using CatalogoApi.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<Categoria>> GetCategorias() => _context.Categoria.AsNoTracking().ToList();

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> GetSingleCategory(int id)
        {
            var categoria = _context.Categoria.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
                return NotFound("Id não encontrada.");

            return categoria;
        }

        [HttpPost]
        public ActionResult PostCategoria([FromBody] Categoria categoria)
        {
            var valida = new ValidaCategoria().ValidaCampos(categoria);


            if (categoria.CategoriaId != 0)
            {
                valida.IsValid = false;
                valida.Errors.Add("Identificador da categoria é adicionado automaticamente e não deve ser passado como parâmetro.");
            }

            if (!valida.IsValid)
                return BadRequest(valida.Errors);
                    


            _context.Categoria.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult PutCategoria(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId || categoria.CategoriaId != 0)
                    return BadRequest();

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Verifique a Id e os demais inputs.");
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> DeleteCategoria(int id)
        {
            try
            {
                var categoria = _context.Categoria.FirstOrDefault(p => p.CategoriaId == id);
                if (categoria == null)
                    return NotFound("Id não encontrada.");

                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
               return BadRequest("Verifique as informações que estão sendo passadas e se a categoria está englobando algum dos produtos. Para deletar uma categoria," +
                           " certifique-se de que esta não está sendo usada por nenhum produto.");
            }
        }
    }
}
