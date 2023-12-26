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
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepositorio _projetoRepositorio;
        private readonly DataContext _bancoContext;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoRepositorio projetoRepositorio, DataContext bancoContext, IMapper mapper)
        {
            _projetoRepositorio = projetoRepositorio;
            _bancoContext = bancoContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            List<ProjetoViewModel> projeto = _projetoRepositorio.BuscarTodas();
            return View(projeto);

        }

        public IActionResult Detalhes(int id)
        {


            ViewBag.Usuario = _bancoContext.Usuario.OrderBy(x => x.Nome);

            Projeto projeto = _projetoRepositorio.ListarPorId(id);
            ProjetoViewModel projetoView = _mapper.Map<ProjetoViewModel>(projeto);
            return View(projetoView);

        }
        public IActionResult Cadastrar()
        {
            ViewBag.Usuario = _bancoContext.Usuario.OrderBy(x => x.Nome);

            ViewBag.Tema = _bancoContext.Tema.Where(x => x.Ativo); 

            ViewBag.Financiamento = _bancoContext.Financiamento.OrderBy(x => x.Tipo);

            ViewBag.Objetivo = _bancoContext.Objetivo.Where(x => x.Ativo); 

            return View();
        }

        public IActionResult Editar(int id)
        {

            ViewBag.Usuario = _bancoContext.Usuario.OrderBy(x => x.Nome);

            ViewBag.Tema = _bancoContext.Tema.Where(x => x.Ativo);

            ViewBag.Financiamento = _bancoContext.Financiamento.OrderBy(x => x.Tipo);

            ViewBag.Objetivo = _bancoContext.Objetivo.Where(x => x.Ativo);

            Projeto projeto = _projetoRepositorio.ListarPorId(id);
            ProjetoViewModel projetoView = _mapper.Map<ProjetoViewModel>(projeto);
            return View(projetoView);
        }

        
        [HttpPost]
        public IActionResult Alterar(ProjetoViewModel projetoView)
        {
            try
            {
                //if (_bancoContext.Projeto.Any(x => x.Nome == projetoView.Nome)) throw new Exception("Objeto ja existe");

                if (ModelState.IsValid)
                {
                    _projetoRepositorio.AplicarEdicao(projetoView);
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
        public IActionResult Cadastrar(ProjetoViewModel projetoView)
        {
            try 
            {
                if (_bancoContext.Projeto.Any(x => x.Nome == projetoView.Nome)) throw new Exception("erro");

                if (projetoView.IdApoio is not null)
                {
                    if(projetoView.IdApoio.Contains(projetoView.IdCliente) || projetoView.IdApoio.Contains(projetoView.IdLTP)) throw new Exception("erro");
                }
                if (ModelState.IsValid)
                {
                    _projetoRepositorio.Adicionar(projetoView);
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



