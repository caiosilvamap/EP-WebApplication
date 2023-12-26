using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroProjeto.Models
{
    public partial class GerenciaGeral
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Gerencia> Gerencia { get; set; } = new List<Gerencia>();

    }
}