using CatalogoApi.Models;

namespace CatalogoApi.Validator
{
    public class ValidaProduto : ValidatorAbstract
    {

        public ValidaProduto ValidaCampos(Produto produto)
        {

            if (produto.Nome is null || produto.Nome.Length == 0 ||  produto.Descricao == null)
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