using App.Interfaces;
using App.ViewModels;
using Domain.Models;
using Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class TemaApp : App<TemaViewModel, Tema>, ITemaApp
    {
        private readonly ITemaRepository _temaRepository;
        public TemaApp(ITemaRepository temaRepository, IMapper mapper) : base(mapper, temaRepository)
        {
            _temaRepository = temaRepository;
        }
        public List<Tema> GetTemas() => _temaRepository.WhereAsync(u => u.Ativo).Result.ToList();     
    }
}
