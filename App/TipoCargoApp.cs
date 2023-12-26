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
    public class TipoCargoApp : App<TipoCargoViewModel, TipoCargo>, ITipoCargoApp
    {
        private readonly ITipoCargoRepository _tipoCargoRepository;
        private readonly IMapper _mapper;

        public TipoCargoApp(ITipoCargoRepository tipoCargoRepository, IMapper mapper ) : base (mapper, tipoCargoRepository)
        {
            _tipoCargoRepository = tipoCargoRepository;
        }
        public List<TipoCargo> GetTipoCargos()
        {
           return _tipoCargoRepository.WhereAsync(u => u.Ativo).Result.ToList();        
        }
    }
}
