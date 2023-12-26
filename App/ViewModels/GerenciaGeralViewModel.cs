using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class GerenciaGeralViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<GerenciaViewModel>? Gerencia { get; set; }
    }
}
