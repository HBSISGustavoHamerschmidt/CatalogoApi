using CatalogoApi.Models;

namespace CatalogoApi.Validator
{
    public class ValidaProduto : ValidatorAbstract
    {

        public ValidaProduto ValidaCampos(Produto produto)
        {

            if (string.IsNullOrEmpty(produto.Nome) ||  string.IsNullOrEmpty(produto.Descricao))
            {
                IsValid = false;
                Errors.Add("Os campos Nome e Descrição não podem ser nulos ou vazios.");
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