﻿using App.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(DataContext context) : base(context)
        {

        }
    }
}