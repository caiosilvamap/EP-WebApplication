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
    public class TipoFuncaoApp : App<TipoFuncaoViewModel, TipoFuncao>, ITipoFuncaoApp
    {
        public TipoFuncaoApp(ITipoFuncaoRepository tipoFuncaoRespository, IMapper mapper) : base(mapper, tipoFuncaoRespository)
        {
               
        }
    }
}
