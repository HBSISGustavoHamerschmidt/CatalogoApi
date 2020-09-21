using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogoApi.Models
{
    public class Produto
    {
        // Always define Length of string
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(30)]
        public string Descricao { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        [MaxLength(300)]
        public string ImageUrl { get; set; }
        [Required]
        public double Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categoria { get; set; }
    }
}