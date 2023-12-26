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
    public class ObjetivoController : Controller
    {
        private readonly IObjetivoApp _objetivoApp;
        public ObjetivoController(IObjetivoApp objetivoApp)
        {
            _objetivoApp = objetivoApp;
        }
        public async Task<IActionResult> Index()
        {
            var objetivoView = await _objetivoApp.FindAllAsync();
            return View(objetivoView);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var objetivoView = await _objetivoApp.FindByIdAsync(id);
            return View(objetivoView);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ObjetivoViewModel objetivoView)
        {
            await _objetivoApp.EditAsync(objetivoView);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ObjetivoViewModel objetivoView)
        {
            await _objetivoApp.CreateAsync(objetivoView);
            return RedirectToAction("Index");
        }
    }
}
