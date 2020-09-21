using CatalogoApi.Models;
using CatalogoApi.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Api.Hbsis.Models.Context;

namespace CatalogoApi.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context) =>_context = context;
        
    [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos() => _context.Produtos.AsNoTracking().ToList();

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> GetSingleProduto(int id)
        {
            var product = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);

            if (product is null)
                return NotFound("Produto não encontrado.");

            return product;
        }

        [HttpPost]
        public ActionResult PostProduto([FromBody] Produto produto)
        {
            var valida = new ValidaProduto().ValidaCampos(produto);

            if (produto.ProdutoId != 0)
            {
                valida.IsValid = false;
                valida.Errors.Add("Id do produto já é inserida automaticamente e não pode ser inserida manualmente.");
            }
            if (!valida.IsValid)
            {
                return BadRequest(valida.Errors);
            }

            produto.DataCadastro = DateTime.Now;
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult PutProduto(int id, [FromBody] Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                    return BadRequest();

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Verifique a Id e os demais inputs.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> DeleteProduto(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if (produto == null)
                    return NotFound("Produto não encontrado.");

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return produto;
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
