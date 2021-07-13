using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Client.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ProdutoId { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Tamanho")]
        public string Tamanho { get; set; }
        [Display(Name = "Coleção")]
        public string Colecao { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [Display(Name = "Imagem")]
        public string ImagemUrl { get; set; }
    }
}
