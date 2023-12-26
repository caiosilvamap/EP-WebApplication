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
    public class ArquivoApp : App<ArquivoViewModel, Arquivo>, IArquivoApp
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IMapper _mapper;

        public ArquivoApp(IArquivoRepository arquivoRepository, IMapper mapper) : base (mapper, arquivoRepository)
        {
            _mapper = mapper;
            _arquivoRepository = arquivoRepository;
        }
    }
}
