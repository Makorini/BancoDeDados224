using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public double Valor { get; set; }
        public long CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }

    }
}