using App.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IUsuarioApp : IApp<UsuarioViewModel, Usuario>
    {
        List<Usuario> GetUsuarios();   
    }
}
