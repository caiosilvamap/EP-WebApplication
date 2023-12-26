using System.Collections.Generic;

namespace Domain.Models
{
    public class TipoCargo
    {
        public int Id { get; set; }

        public string Cargo { get; set; }

        public bool Ativo { get;}

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
