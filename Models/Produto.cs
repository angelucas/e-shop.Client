using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Client.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public string Colecao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
