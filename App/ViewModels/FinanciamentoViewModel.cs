using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class FinanciamentoViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;

    }
}
