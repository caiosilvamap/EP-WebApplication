using SistemaCadastroProjeto.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProjeto.ViewModels
{
    public class GerenciaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome da Gerência")]
        public string Nome { get; set; }

        [ForeignKey("IdGerenciaGeralNavigation")]
        public int IdGerenciaGeral { get; set; }

        public virtual GerenciaGeralViewModel? IdGerenciaGeralNavigation { get; set; }

        public bool Ativo { get; set; }

    
    }
}
