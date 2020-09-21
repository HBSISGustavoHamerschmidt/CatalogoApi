using CatalogoApi.Models;
using Web.Api.Hbsis.Models.Context;

namespace CatalogoApi.Validator
{
    public class ValidaProduto : ValidatorAbstract
    {
        private readonly AppDbContext _context;
        public ValidaProduto(AppDbContext context) => _context = context;

        public ValidaProduto ValidaCampos(Produto produto)
        {

            if (produto.Nome is null || produto.ImageUrl is null || produto.Nome.Length == 0 || produto.ImageUrl.Length == 0 || produto.Descricao == null)
            {
                IsValid = false;
                Errors.Add("Os campos Nome, Descrição e ImageUrl não podem ser nulos ou vazios.");
            }

            if (Regex.IsMatch(produto.Nome))
            {
                IsValid = false;
                Errors.Add("O campo Nome só pode conter caracteres sem acento e espaços.");
            }

            return this;
        }
    }
}