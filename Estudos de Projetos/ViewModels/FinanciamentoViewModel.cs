using SistemaCadastroProjeto.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroProjeto.ViewModels
{
    public class FinanciamentoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Tipo de Financiamento")]
        public string Tipo { get; set; } = null!;

    }
}
