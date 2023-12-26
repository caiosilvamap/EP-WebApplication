using App.Interfaces;
using App.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class FinanciamentoApp : App<FinanciamentoViewModel, Financiamento>, IFinanciamentoApp
    {
        private readonly IFinanciamentoRepository _financiamentoRepository;
        private readonly IMapper _mapper;
        public FinanciamentoApp(IFinanciamentoRepository financiamentoRepository, IMapper mapper) : base (mapper, financiamentoRepository)
        {
            _mapper = mapper;
            _financiamentoRepository = financiamentoRepository;
        }
        public List<Financiamento> GetFinanciamentos() => _financiamentoRepository.FindAllAsync().Result.ToList();
    }
}
