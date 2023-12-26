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
    public class ObjetivoController : Controller
    {
        private readonly IObjetivoRepositorio _objetivoRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;


        public ObjetivoController(IObjetivoRepositorio objetivoRepositorio, DataContext bancoContext, IMapper mapper)
        {
            _mapper = mapper;
            _bancoContext = bancoContext;
            _objetivoRepositorio = objetivoRepositorio;          
        }
        public IActionResult Index()
        {
            List<ObjetivoViewModel> objetivo = _objetivoRepositorio.BuscarTodas();
            return View(objetivo);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Objetivo objetivo = _objetivoRepositorio.ListarPorId(id);
            ObjetivoViewModel objetivoView = _mapper.Map<ObjetivoViewModel>(objetivo);
            return View(objetivoView);
        }


        [HttpPost]
        public IActionResult Alterar(ObjetivoViewModel objetivoView)
        {
            try
            {
                if (_bancoContext.Objetivo.Any(x => x.Nome == objetivoView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _objetivoRepositorio.AplicarEdicao(objetivoView);
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
        public IActionResult Cadastrar(ObjetivoViewModel objetivoView)
        {
            try
            {
                if (_bancoContext.Objetivo.Any(x => x.Nome == objetivoView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _objetivoRepositorio.Adicionar(objetivoView);
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
