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
    public class TemaController : Controller
    {

        private readonly ITemaApp _temaApp;

        public TemaController(ITemaApp temaApp)
        {
            _temaApp = temaApp;
        }

        public async Task<IActionResult> Index()
        {
            var temaView = await _temaApp.FindAllAsync();
            return View(temaView);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var temaView = await _temaApp.FindByIdAsync(id);
            return View(temaView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TemaViewModel temaView)
        {
            await _temaApp.EditAsync(temaView);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TemaViewModel temaView)
        {
            await _temaApp.CreateAsync(temaView);
            return RedirectToAction("Index");
        }
    }
}
