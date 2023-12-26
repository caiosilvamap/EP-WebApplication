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
    public class ObjetivoApp : App<ObjetivoViewModel, Objetivo>, IObjetivoApp
    {
        private readonly IObjetivoRepository _objetivoRepository;
        public ObjetivoApp(IObjetivoRepository objetivoRepository, IMapper mapper) : base(mapper, objetivoRepository)
        {
            _objetivoRepository = objetivoRepository;
        }
        public List<Objetivo> GetObjetivos() => _objetivoRepository.WhereAsync(u => u.Ativo).Result.ToList();
    }
}
