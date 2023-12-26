using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class TemaViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public bool Ativo { get; set; }

        //public virtual ICollection<Projeto>? Projetos { get; set; } = new List<Projeto>();
    }
}