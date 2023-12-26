using App.Interfaces;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroProjeto.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoApp _projetoApp;
        private readonly IUsuarioApp _usuarioApp;
        private readonly ITemaApp _temaApp;
        private readonly IObjetivoApp _objetivoApp;
        private readonly IFinanciamentoApp _financiamentoApp;
        public ProjetoController(IProjetoApp projetoApp
            , IUsuarioApp usuarioApp
            , ITemaApp temaApp
            , IObjetivoApp objetivoApp
            , IFinanciamentoApp financiamentoApp)
        {
            _projetoApp = projetoApp;
            _usuarioApp = usuarioApp;
            _temaApp = temaApp;
            _objetivoApp = objetivoApp;
            _financiamentoApp = financiamentoApp;
        }

        public async Task<IActionResult> Index()
        {
           var projetoView = await _projetoApp.FindAllAsync();
           return View(projetoView);
        }

        //public IActionResult Detalhes(int id)
        //{


        //    ViewBag.Usuario = _bancoContext.Usuario.OrderBy(x => x.Nome);

        //    Projeto projeto = _projetoRepositorio.ListarPorId(id);
        //    ProjetoViewModel projetoView = _mapper.Map<ProjetoViewModel>(projeto);
        //    return View(projetoView);

        //}
        public IActionResult Create()
        {
            ViewBag.Usuario = _usuarioApp.GetUsuarios();

            ViewBag.Tema = _temaApp.GetTemas();

            ViewBag.Financiamento = _financiamentoApp.GetFinanciamentos();

            ViewBag.Objetivo = _objetivoApp.GetObjetivos();

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Usuario = _usuarioApp.GetUsuarios();

            ViewBag.Tema = _temaApp.GetTemas();

            ViewBag.Financiamento = _financiamentoApp.GetFinanciamentos();

            ViewBag.Objetivo = _objetivoApp.GetObjetivos();

            var projetoView = await _projetoApp.FindByIdAsync(id);

            return View(projetoView);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProjetoViewModel projetoView)
        {
            await _projetoApp.EditAsync(projetoView);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProjetoViewModel projetoView)
        {
            await _projetoApp.CreateAsync(projetoView);
            return RedirectToAction("Index");
        }
    }
}



