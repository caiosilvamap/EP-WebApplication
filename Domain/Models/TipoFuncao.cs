using System;
using System.Collections.Generic;

namespace Domain.Models
{ 
    public partial class TipoFuncao
    {
        public int Id { get; set; }

        public string Funcao { get; set; } = null!;

        public virtual ICollection<UsuarioProjeto> UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();
    }
}