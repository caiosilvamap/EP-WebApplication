using Domain.Models;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class TipoCargoViewModel
    {
        public int Id { get; set; }

        public string Cargo { get; set; }

        public bool Ativo { get; }

        public virtual ICollection<UsuarioProjeto> UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();

    }
}
