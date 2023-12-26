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
    public class GerenciaController : Controller
    {

        private readonly IGerenciaApp _gerenciaApp;
        private readonly IGerenciaGeralApp _gerenciaGeralApp;
        public GerenciaController(IGerenciaApp gerenciaApp, IGerenciaGeralApp gerenciaGeralApp)
        {
            _gerenciaApp = gerenciaApp;
            _gerenciaGeralApp = gerenciaGeralApp;
        }

        public async Task<IActionResult> Index()
        {
            var gerenciaView = await _gerenciaApp.FindAllAsync();
            return View(gerenciaView);
        }


        public  IActionResult Create()
        {
            ViewBag.gerenciaGeral = _gerenciaGeralApp.GetGerenciaGeral();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.gerenciaGeral = await _gerenciaApp.WhereAsync(u => u.IdGerenciaGeralNavigation.Ativo);
            var gerenciaView = await _gerenciaApp.FindByIdAsync(id);
            return View(gerenciaView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GerenciaViewModel gerenciaView)
        {
            await _gerenciaApp.EditAsync(gerenciaView);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(GerenciaViewModel gerenciaView)
        {
            await _gerenciaApp.CreateAsync(gerenciaView);
            return RedirectToAction("Index");
        }
    }
}
