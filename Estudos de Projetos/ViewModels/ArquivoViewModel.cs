using SistemaCadastroProjeto.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProjeto.ViewModels
{
    public class ArquivoViewModel
    {
        public int Id { get; set; }

        [ForeignKey("IdProjetoNavigation")]
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public virtual ProjetoViewModel IdProjetoNavigation { get; set; }

    }
}
