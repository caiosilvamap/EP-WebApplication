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
    public class FinanciamentoController : Controller
    {
        
        private readonly IFinanciamentoRepositorio _financiamentoRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;   

        public FinanciamentoController(IFinanciamentoRepositorio financiamentoRepositorio, DataContext bancoContext, IMapper mapper)           
        {
            _mapper = mapper;
            _bancoContext=bancoContext;
            _financiamentoRepositorio = financiamentoRepositorio;
        }

        public IActionResult Index()
        {
            List<FinanciamentoViewModel> financiamento = _financiamentoRepositorio.BuscarTodas();
            return View(financiamento);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Financiamento financiamento = _financiamentoRepositorio.ListarPorId(id);
            FinanciamentoViewModel financiamentoView = _mapper.Map<FinanciamentoViewModel>(financiamento);
            return View(financiamentoView);
        }

       [HttpPost]
       public IActionResult Alterar(FinanciamentoViewModel financiamentoView)
       {
            try
            {
                if (_bancoContext.Financiamento.Any(x => x.Tipo == financiamentoView.Tipo)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _financiamentoRepositorio.AplicarEdicao(financiamentoView);
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
       public IActionResult Cadastrar(FinanciamentoViewModel financiamentoView)
       {
            try 
            {
                if (_bancoContext.Financiamento.Any(x => x.Tipo == financiamentoView.Tipo)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _financiamentoRepositorio.Adicionar(financiamentoView);
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
    }
}
