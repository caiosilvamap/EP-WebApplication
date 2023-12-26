
using App.Interfaces;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ITipoCargoApp _tipoCargoApp;
        private readonly IUsuarioApp _usuarioApp;
        private readonly IGerenciaApp _gerenciaApp;
        public UsuarioController(IUsuarioApp usuarioApp, IGerenciaApp gerenciaApp, ITipoCargoApp tipoCargoApp)
        {
            _tipoCargoApp = tipoCargoApp; 
            _usuarioApp = usuarioApp;
            _gerenciaApp = gerenciaApp;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioView = await _usuarioApp.FindAllAsync();
            return View(usuarioView);
        }

        public IActionResult Create()
        {
            ViewBag.cargo = _tipoCargoApp.GetTipoCargos();
            ViewBag.gerencia = _gerenciaApp.GetGerencias();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.cargo = _tipoCargoApp.GetTipoCargos();
            ViewBag.gerencia = _gerenciaApp.GetGerencias();
            var usuarioView = await _usuarioApp.FindByIdAsync(id);          
            return View(usuarioView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioViewModel usuarioView)
        {
            await _usuarioApp.EditAsync(usuarioView);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioView)
        {
            await _usuarioApp.CreateAsync(usuarioView);
            return RedirectToAction("Index");
        }
    }
}
