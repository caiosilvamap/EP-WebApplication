using Microsoft.AspNetCore.Http;
using SistemaCadastroProjeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProjeto.ViewModels
{
    public class ProjetoViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Tema é Obrigatório")]
        [ForeignKey("IdTemaNavigation")]
        public int IdTema { get; set; }

        [Required(ErrorMessage = "Campo Financiamento é Obrigatório")]
        [ForeignKey("IdFinanciamentoNavigation")]
        public int IdFinanciamento { get; set; }

        [Required(ErrorMessage = "Campo Objetivo é Obrigatório")]
        [ForeignKey("IdObjetivoNavigation")]
        public int IdObjetivo { get; set; }

        [Required(ErrorMessage = "Campo Nome é Obrigatorio")]
        public string Nome { get; set; }

        public string? Codigo { get; set; }

        public DateTime? DataAbertura { get; set; }

        [Required(ErrorMessage = "Campo LTP é Obrigatório")]
        [ForeignKey("UsuarioProjeto")]
        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "Campo LTP é Obrigatório")]
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

