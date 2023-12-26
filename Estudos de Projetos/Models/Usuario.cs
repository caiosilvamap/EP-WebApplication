
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProjeto.Models
{
    public partial class Usuario
    {

        public int Id { get; set; }

        [ForeignKey("IdGerenciaNavigation")]
        public int IdGerencia { get; set; }

        public string Nome { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string? Email { get; set; }

        [ForeignKey("IdTipoCargoNavigation")]
        public int IdTipoCargo { get; set; }

        public virtual TipoCargo IdTipoCargoNavigation { get; set; } = null!;

        public virtual Gerencia IdGerenciaNavigation { get; set; } = null!;

        public virtual ICollection<UsuarioProjeto> UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();
    }
}