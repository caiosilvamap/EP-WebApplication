using System;
using System.Collections.Generic;

namespace SistemaCadastroProjeto.Models
{
    public partial class Tema
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
    }
}