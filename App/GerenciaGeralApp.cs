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
    public class GerenciaGeralApp : App<GerenciaGeralViewModel, GerenciaGeral>, IGerenciaGeralApp
    {
        private readonly IGerenciaGeralRepository _gerenciaGeralRepository;

        public GerenciaGeralApp(IGerenciaGeralRepository gerenciaGeralRepository, IMapper mapper) : base(mapper, gerenciaGeralRepository)
        {
            _gerenciaGeralRepository = gerenciaGeralRepository;
        }

        public List<GerenciaGeral> GetGerenciaGeral() => _gerenciaGeralRepository.WhereAsync(u => u.Ativo).Result.ToList();
    }
}
