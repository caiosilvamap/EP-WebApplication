using SistemaCadastroProjeto.Models;
using System.Collections.Generic;

namespace SistemaCadastroProjeto.ViewModels
{
    public class TipoFuncaoViewModel
    {
        public int Id { get; set; }

        public string Funcao { get; set; } = null!;

        public virtual ICollection<UsuarioProjeto> UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();
    }
}
