

using System.Collections.Generic;

namespace SistemaCadastroProjeto.Models
{
    public partial class Objetivo
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public bool Ativo { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
    }
}