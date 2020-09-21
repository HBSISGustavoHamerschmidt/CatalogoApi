using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CatalogoApi.Validator
{
    public abstract class ValidatorAbstract
    {
        public bool IsValid { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        public Regex Regex { get; set; } = new Regex("[^A-z\\s]");
    }
}