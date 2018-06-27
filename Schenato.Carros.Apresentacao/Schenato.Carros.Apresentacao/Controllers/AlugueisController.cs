using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Infraestrutura.Contexto;
using Schenato.Carros.Infraestrutura.Repositorios;

namespace Schenato.Carros.Apresentacao.Controllers
{
    public class AlugueisController : Controller
    {
        private AluguelRepositorio _repositorio = new AluguelRepositorio();
        private PessoaRepositorio _repositorioClientes = new PessoaRepositorio();
        private AutomovelRepositorio _repositorioAutomoveis = new AutomovelRepositorio();

        // GET: Alugueis
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Alugueis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = _repositorio.BuscarPor((int)id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // GET: Alugueis/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = _repositorioClientes.BuscarTudo();
            ViewBag.Automoveis = _repositorioAutomoveis.BuscarTudo();
            return View();
        }

        // POST: Alugueis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cliente,Automovel,ValorTotal,DataInicio,DataFim")] Aluguel aluguel)
        {
            ViewBag.Clientes = _repositorioClientes.BuscarTudo();
            ViewBag.Automoveis = _repositorioAutomoveis.BuscarTudo();
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(aluguel);
                return RedirectToAction("Index");
            }

            return View(aluguel);
        }

        // GET: Alugueis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = _repositorio.BuscarPor((int)id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // POST: Alugueis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cliente,Automovel,ValorTotal,DataInicio,DataFim")] Aluguel aluguel)
        {
            Aluguel aluguelEditado = _repositorio.BuscarPor(aluguel.Id);
            aluguelEditado.Cliente = aluguel.Cliente;
            aluguelEditado.Automovel = aluguel.Automovel;
            aluguelEditado.DataInicio = aluguel.DataInicio;
            aluguelEditado.DataFim = aluguel.DataFim;
            if (ModelState.IsValid)
            {
                _repositorio.Editar(aluguelEditado);
                return RedirectToAction("Index");
            }
            return View(aluguel);
        }

        // GET: Alugueis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = _repositorio.BuscarPor((int)id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // POST: Alugueis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluguel aluguel = _repositorio.BuscarPor((int)id);
            _repositorio.Deletar(aluguel);
            return RedirectToAction("Index");
        }
    }
}
