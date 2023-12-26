using SistemaCadastroProjeto.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProjeto.ViewModels
{
    public class UsuarioViewModel
    {   
            public int Id { get; set; }

            [ForeignKey("IdGerenciaNavigation")]
            public int IdGerencia { get; set; }

            [Required(ErrorMessage = "Digite o Nome do Usuário")]
            public string Nome { get; set; } = null!;

            [ForeignKey("IdTipoCargoNavigation")]
            public int IdTipoCargo { get; set; }

            public virtual TipoCargoViewModel? IdTipoCargoNavigation { get; set; } 
            public string Telefone { get; set; } = null!;

            public string? Email { get; set; }

            public virtual GerenciaViewModel? IdGerenciaNavigation { get; set; } 

            //public virtual ICollection<UsuarioProjeto>? UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();
        
    }
}
