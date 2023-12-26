using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SistemaCadastroProjeto.Data;
using SistemaCadastroProjeto.Models;
using SistemaCadastroProjeto.Repositório;
using SistemaCadastroProjeto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCadastroProjeto.Controllers
{
    public class GerenciaController : Controller
    {
        
        private readonly IGerenciaRepositorio _gerenciaRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;
        public GerenciaController(IGerenciaRepositorio gerenciaRepositorio, DataContext bancoContext, IMapper mapper)           
        {
            _mapper = mapper;
            _bancoContext = bancoContext;
            _gerenciaRepositorio = gerenciaRepositorio;
        }

        public IActionResult Index()
        {
            List<GerenciaViewModel> gerencia = _gerenciaRepositorio.BuscarTodas();
            return View(gerencia);
        }

     
        public IActionResult Cadastrar()
        {
            ViewBag.gerenciaGeral = _bancoContext.GerenciaGeral.Where(x => x.Ativo);
            return View();
        }

        public IActionResult Editar(int id)
        {
            ViewBag.gerenciaGeral = _bancoContext.GerenciaGeral.Where(x => x.Ativo);
            Gerencia gerencia = _gerenciaRepositorio.ListarPorId(id);
            GerenciaViewModel gerenciaView = _mapper.Map<GerenciaViewModel>(gerencia);
            return View(gerenciaView);
        }

       [HttpPost]
       public IActionResult Alterar(GerenciaViewModel gerenciaView)
       {
            try
            {
                if (_bancoContext.Gerencia.Any(x => x.Nome == gerenciaView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _gerenciaRepositorio.AplicarEdicao(gerenciaView);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

       [HttpPost]
       public IActionResult Cadastrar(GerenciaViewModel gerenciaView)
       {
            try
            {
                if (_bancoContext.Gerencia.Any(x => x.Nome == gerenciaView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _gerenciaRepositorio.Adicionar(gerenciaView);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
           
       }
    }
}
