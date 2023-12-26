using SistemaCadastroProjeto.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroProjeto.ViewModels
{
    public class ObjetivoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Objetivo")]

        public string Nome { get; set; } = null!;

        public bool Ativo { get; set; }

        //public virtual ICollection<Projeto>? Projetos { get; set; } = new List<Projeto>();
    }
}
