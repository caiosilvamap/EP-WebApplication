using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.ViewModels
{
    public class ProjetoViewModel
    {

        public int Id { get; set; }

        [ForeignKey("IdTemaNavigation")]
        public int IdTema { get; set; }

        [ForeignKey("IdFinanciamentoNavigation")]
        public int IdFinanciamento { get; set; }

        [ForeignKey("IdObjetivoNavigation")]
        public int IdObjetivo { get; set; }

        public string Nome { get; set; }

        public string? Codigo { get; set; }

        public DateTime? DataAbertura { get; set; }

        [ForeignKey("UsuarioProjeto")]
        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }

        [ForeignKey("UsuarioProjeto")]
        public int IdLTP { get; set; }
        public string? NomeLTP { get; set; }

        [ForeignKey("UsuarioProjeto")]
        public List<int>? IdApoio { get; set; }
        public List<string>? NomeApoio { get; set; }
        public virtual IList<IFormFile>? LstArquivo { get; set; }
        public List<string>? NomeArquivo { get; set; }
        public virtual UsuarioViewModel? Usuario { get; set; }
        public virtual UsuarioProjetoViewModel? UsuarioProjeto { get; set; }

        public virtual FinanciamentoViewModel? IdFinanciamentoNavigation { get; set; } 

        public virtual ObjetivoViewModel? IdObjetivoNavigation { get; set; } 

        public virtual TemaViewModel? IdTemaNavigation { get; set; }


        //public virtual ICollection<UsuarioProjeto> UsuarioProjetos { get; set; } = new List<UsuarioProjeto>();


    }
}

