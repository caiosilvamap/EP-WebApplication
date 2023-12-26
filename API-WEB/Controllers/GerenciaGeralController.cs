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
    public class GerenciaGeralController : Controller
    {
        private readonly IGerenciaGeralApp _gerenciaGeralApp;
        public GerenciaGeralController(IGerenciaGeralApp gerenciaGeralApp)
        {
            _gerenciaGeralApp = gerenciaGeralApp;
        }
        public async Task<IActionResult> Index()
        {
            var gerenciaGeralView = await _gerenciaGeralApp.FindAllAsync();
            return View(gerenciaGeralView);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gerenciaGeralView = await _gerenciaGeralApp.FindByIdAsync(id);
            return View(gerenciaGeralView);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(GerenciaGeralViewModel gerenciaGeralView)
        {
            await _gerenciaGeralApp.EditAsync(gerenciaGeralView);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Create(GerenciaGeralViewModel gerenciaGeralView)
        {
            await _gerenciaGeralApp.CreateAsync(gerenciaGeralView);
            return RedirectToAction("Index");
        }

    }
}
