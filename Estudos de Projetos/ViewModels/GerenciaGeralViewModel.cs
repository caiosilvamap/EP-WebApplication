using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroProjeto.ViewModels
{
    public class GerenciaGeralViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome da Gerência Geral")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<GerenciaViewModel>? Gerencia { get; set; }
    }
}
