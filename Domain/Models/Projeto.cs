using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public partial class Projeto
    {
        public int Id { get; set; }


        [ForeignKey("IdTemaNavigation")]
        public int IdTema { get; set; }

        [ForeignKey("IdFinanciamentoNavigation")]
        public int IdFinanciamento { get; set; }

        [ForeignKey("IdObjetivoNavigation")]
        public int IdObjetivo { get; set; }

        public string Nome { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public DateTime DataAbertura { get; set; }

        public virtual Financiamento IdFinanciamentoNavigation { get; set; } = null!;

        public virtual Objetivo IdObjetivoNavigation { get; set; } = null!;

        public virtual Tema IdTemaNavigation { get; set; } = null!;

        public virtual ICollection<Arquivo>? LstArquivo { get; set; } = new List<Arquivo>();

        public virtual ICollection<UsuarioProjeto> UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();
    }
}