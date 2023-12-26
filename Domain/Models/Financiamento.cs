﻿
using System.Collections.Generic;

namespace Domain.Models
{

    public partial class Financiamento
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = null!;

        public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
    }
}