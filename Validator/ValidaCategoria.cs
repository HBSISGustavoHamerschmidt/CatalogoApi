using CatalogoApi.Models;

namespace CatalogoApi.Validator
{
    public class ValidaCategoria : ValidatorAbstract
    {
        public ValidaCategoria ValidaCampos(Categoria categoria)
        {

            if (categoria.Nome is null || categoria.ImageUrl is null || categoria.Nome.Length == 0 || categoria.ImageUrl.Length == 0)
            {
                IsValid = false;
                Errors.Add("Os campos Nome e ImageUrl não podem ser nulos ou vazios.");
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