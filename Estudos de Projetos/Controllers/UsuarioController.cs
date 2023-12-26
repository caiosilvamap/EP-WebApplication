using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroProjeto.Data;
using SistemaCadastroProjeto.Models;
using SistemaCadastroProjeto.Repositório;
using SistemaCadastroProjeto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCadastroProjeto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, DataContext bancoContext, IMapper mapper)
        {
            _mapper = mapper;
            _bancoContext = bancoContext;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioViewModel> usuario = _usuarioRepositorio.BuscarTodas();
            return View(usuario);
        }

        public IActionResult Cadastrar()
        {
            ViewBag.cargo = _bancoContext.TipoCargo.Where(x => x.Ativo);
            ViewBag.gerencia = _bancoContext.Gerencia.Where(x => x.Ativo);
            return View();
        }

        public IActionResult Editar(int id)
        {
            ViewBag.cargo = _bancoContext.TipoCargo.Where(x => x.Ativo);
            ViewBag.gerencia = _bancoContext.Gerencia.Where(x => x.Ativo);
            Usuario usuario = _usuarioRepositorio.ListarPorId(id);
            UsuarioViewModel usuarioView = _mapper.Map<UsuarioViewModel>(usuario);
            return View(usuarioView);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioViewModel usuarioView)
        {
            try
            {
                if (_bancoContext.Usuario.Any(x => x.Nome == usuarioView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AplicarEdicao(usuarioView);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioViewModel usuarioView)
        {
            try
            {
                if (_bancoContext.Usuario.Any(x => x.Nome == usuarioView.Nome)) throw new Exception("Objeto ja existe"); 

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuarioView);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }

        }
    }
}
