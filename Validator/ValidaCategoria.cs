using CatalogoApi.Models;

namespace CatalogoApi.Validator
{
    public class ValidaCategoria : ValidatorAbstract
    {
        public ValidaCategoria ValidaCampos(Categoria categoria)
        {

            if (string.IsNullOrEmpty(categoria.Nome))
            {
                IsValid = false;
                Errors.Add("O campo Nome não pode ser nulo ou vazio.");
            }

            if (Regex.IsMatch(categoria.Nome))
            {
                IsValid = false;
                Errors.Add("O campo Nome só pode conter caracteres sem acento e espaços.");
            }

            return this;
        }
    }
}