using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoApi.Models;
using CatalogoApi.Repo;
using CatalogoApi.Validator;
using Web.Api.Hbsis.Models.Context;

namespace CatalogoApi.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICatalogoRepo<Categoria> _repository;
        public CategoriasController(ICatalogoRepo<Categoria> repository) => _repository = repository;

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            return Ok(_repository.GetAll());

            return _context.Categoria.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> GetSingleCategory(int id)
        {
            var category = _context.Categoria.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

            if (category == null)
                return NotFound("Id não encontrada.");

            return category;
        }

        [HttpPost]
        public ActionResult PostCategoria([FromBody] Categoria categoria)
        {
            var valida = new ValidaCategoria(_context).ValidaCampos(categoria);


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

            if (id != categoria.CategoriaId || id == 0)
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
                return NotFound("Id não encontrada.");

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}
