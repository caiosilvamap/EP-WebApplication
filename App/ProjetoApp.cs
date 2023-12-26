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
    public class ProjetoApp : App<ProjetoViewModel, Projeto>, IProjetoApp
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;
        public ProjetoApp(IProjetoRepository projetoRepository, IMapper mapper) : base (mapper, projetoRepository)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }
    }
}
