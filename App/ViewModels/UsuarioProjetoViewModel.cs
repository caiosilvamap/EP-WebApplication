using System.ComponentModel.DataAnnotations.Schema;

namespace App.ViewModels
{
    public class UsuarioProjetoViewModel
    {
        public int IdUsuario { get; set; }

        public int IdProjeto { get; set; }

        [ForeignKey("IdTipoFuncaoNavigation")]
        public int IdTipoFuncao { get; set; }

        public virtual ProjetoViewModel IdProjetoNavigation { get; set; } = null!;

        public virtual TipoFuncaoViewModel IdTipoFuncaoNavigation { get; set; } = null!;
        public virtual UsuarioViewModel Cliente { get; set; }

        public virtual UsuarioViewModel LTP { get; set; }

    }
}
