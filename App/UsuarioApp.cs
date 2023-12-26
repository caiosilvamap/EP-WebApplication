using App.Interfaces;
using App.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class UsuarioApp : App<UsuarioViewModel, Usuario>, IUsuarioApp
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioApp(IUsuarioRepository usuarioRepository, IMapper mapper) : base (mapper, usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public override async Task<UsuarioViewModel> EditAsync (UsuarioViewModel usuarioView)
        {
            var model = await _usuarioRepository.FindByIdAsync(usuarioView.Id);

            model.Email = usuarioView.Email;
            model.IdGerencia = usuarioView.IdGerencia;
            model.IdTipoCargo = usuarioView.IdTipoCargo;
            model.Nome = usuarioView.Nome;
            model.Telefone = usuarioView.Telefone;

            await _usuarioRepository.EditAsync(model);

            return usuarioView;

        }

        public List<Usuario> GetUsuarios() => _usuarioRepository.FindAllAsync().Result.ToList();

        public Task<IEnumerable<GerenciaViewModel>> WhereAsync(Expression<Func<Gerencia, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }
}
