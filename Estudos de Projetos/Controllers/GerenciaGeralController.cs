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
    public class GerenciaGeralController : Controller
    {
        private readonly IGerenciaGeralRepositorio _gerenciaGeralRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;
        public GerenciaGeralController(IGerenciaGeralRepositorio gerenciaGeralRepositorio, DataContext bancoContext, IMapper mapper)
        {
            _bancoContext = bancoContext;
            _gerenciaGeralRepositorio = gerenciaGeralRepositorio;    
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<GerenciaGeralViewModel> gerenciaGeral = _gerenciaGeralRepositorio.BuscarTodas();

            return View(gerenciaGeral);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            GerenciaGeral gerenciaGeral = _gerenciaGeralRepositorio.ListarPorId(id);
            GerenciaGeralViewModel gerenciaGeralView = _mapper.Map<GerenciaGeralViewModel>(gerenciaGeral);
            return View(gerenciaGeralView);
        }

      
        [HttpPost]
        public IActionResult Alterar(GerenciaGeralViewModel gerenciaGeralView)
        {
            try
            {
                if (_bancoContext.GerenciaGeral.Any(x => x.Nome == gerenciaGeralView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _gerenciaGeralRepositorio.AplicarEdicao(gerenciaGeralView);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }
    

        [HttpPost]
        public IActionResult Cadastrar(GerenciaGeralViewModel gerenciaGeralView)
        {
            try
            {
                if (_bancoContext.GerenciaGeral.Any(x => x.Nome == gerenciaGeralView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _gerenciaGeralRepositorio.Adicionar(gerenciaGeralView);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
           

            return RedirectToAction("Index");
        }


    }
}
