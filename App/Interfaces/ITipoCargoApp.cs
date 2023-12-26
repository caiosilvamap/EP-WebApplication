using App.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface ITipoCargoApp : IApp<TipoCargoViewModel, TipoCargo>
    {
      List<TipoCargo> GetTipoCargos();
    }
}
