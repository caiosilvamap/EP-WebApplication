﻿using Domain.Interfaces;
using Domain.Models;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UsuarioRepositrory : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositrory(DataContext context) : base(context)
        {

        }
    }
}
