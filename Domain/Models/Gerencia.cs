

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public partial class Gerencia
    {
        public int Id { get; set; }

        [ForeignKey("IdGerenciaGeralNavigation")]
        public int IdGerenciaGeral { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual GerenciaGeral IdGerenciaGeralNavigation { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}