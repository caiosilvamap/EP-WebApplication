using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.ViewModels
{
    public class GerenciaViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [ForeignKey("IdGerenciaGeralNavigation")]
        public int IdGerenciaGeral { get; set; }

        public virtual GerenciaGeralViewModel? IdGerenciaGeralNavigation { get; set; }

        public bool Ativo { get; set; }

    
    }
}
