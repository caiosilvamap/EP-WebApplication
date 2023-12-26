using App.Interfaces;
using App.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class GerenciaApp : App<GerenciaViewModel, Gerencia>, IGerenciaApp
    {
        private readonly IGerenciaRepository _gerenciaRepository;
        
        public GerenciaApp(IGerenciaRepository gerenciaRepository, IMapper mapper) : base( mapper, gerenciaRepository)
        {
            _gerenciaRepository = gerenciaRepository;
        }
        public List<Gerencia> GetGerencias() => _gerenciaRepository.WhereAsync(u => u.Ativo).Result.ToList();
    }
}
