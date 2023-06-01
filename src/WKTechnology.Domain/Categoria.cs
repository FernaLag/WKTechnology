using System.ComponentModel.DataAnnotations;
using WKTechnology.Domain.Common;

namespace WKTechnology.Domain
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public Categoria()
        {
            Nome = string.Empty;
            Produtos = new List<Produto>();
        }
    }
}