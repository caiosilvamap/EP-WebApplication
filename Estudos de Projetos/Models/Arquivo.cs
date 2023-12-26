using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProjeto.Models
{
    public class Arquivo
    {
        public int Id { get; set; }

        [ForeignKey("IdProjetoNavigation")]
        public int IdProjeto { get; set; }
        public string? Nome { get; set; }
        public virtual Projeto? IdProjetoNavigation { get; set; }

    }
}
