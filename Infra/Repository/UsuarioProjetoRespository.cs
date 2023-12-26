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
    public class UsuarioProjetoRespository : Repository<UsuarioProjeto>, IUsuarioProjetoRepository
    {
        public UsuarioProjetoRespository(DataContext context) : base(context)
        {

        }
    }
}
