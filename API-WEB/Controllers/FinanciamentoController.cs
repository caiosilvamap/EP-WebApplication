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
    public class FinanciamentoController : Controller
    {

        private readonly IFinanciamentoApp _financiamentoApp;

        public FinanciamentoController(IFinanciamentoApp financiamentoApp)
        {
            _financiamentoApp = financiamentoApp;
        }

        public async Task<IActionResult> Index()
        {
            var financiamentoView = await _financiamentoApp.FindAllAsync();
            return View(financiamentoView);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var financiamentoView = await _financiamentoApp.FindByIdAsync(id);
            return View(financiamentoView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FinanciamentoViewModel financiamentoView)
        {
            await _financiamentoApp.EditAsync(financiamentoView);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FinanciamentoViewModel financiamentoView)
        {
            await _financiamentoApp.CreateAsync(financiamentoView);
            return RedirectToAction("Index");
        }
    }
}
