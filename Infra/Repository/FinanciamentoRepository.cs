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
    public class FinanciamentoRepository : Repository<Financiamento>, IFinanciamentoRepository
    {
        public FinanciamentoRepository(DataContext context) : base(context)
        {
        }
    }
}
