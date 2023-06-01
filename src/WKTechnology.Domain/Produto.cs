using System.ComponentModel.DataAnnotations;
using WKTechnology.Domain.Common;

namespace WKTechnology.Domain
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public Produto()
        {
            Nome = string.Empty;
            IdCategoria = 0;
            Categoria = new Categoria();
        }
    }
}