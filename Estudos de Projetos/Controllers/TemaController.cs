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
    public class TemaController : Controller
    {
        
        private readonly ITemaRepositorio _TemaRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;

        public TemaController(ITemaRepositorio temaRepositorio, DataContext bancoContext, IMapper mapper)            
        {
            _mapper = mapper;
            _TemaRepositorio = temaRepositorio;
            _bancoContext = bancoContext;
        }

        public IActionResult Index()
        {
            List<TemaViewModel> tema = _TemaRepositorio.BuscarTodas();
            return View(tema);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Tema tema = _TemaRepositorio.ListarPorId(id);
            TemaViewModel temaView = _mapper.Map<TemaViewModel>(tema);
            return View(temaView);
        }

       [HttpPost]
       public IActionResult Alterar(TemaViewModel temaView)
       {
            try
            {
                if (_bancoContext.Tema.Any(x => x.Nome == temaView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _TemaRepositorio.AplicarEdicao(temaView);
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
        public IActionResult Cadastrar(TemaViewModel temaView)
        {
            try 
            {
                if (_bancoContext.Tema.Any(x => x.Nome == temaView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _TemaRepositorio.Adicionar(temaView);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
             
  
        }
    }
}
