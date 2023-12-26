using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public partial class UsuarioProjeto
    {
        [ForeignKey("IdUsuarioNavigation")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdProjetoNavigation")]
        public int IdProjeto { get; set; }

        [ForeignKey("IdTipoFuncaoNavigation")]
        public int IdTipoFuncao { get; set; }

        public virtual Projeto IdProjetoNavigation { get; set; } = null!;

        public virtual TipoFuncao IdTipoFuncaoNavigation { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}