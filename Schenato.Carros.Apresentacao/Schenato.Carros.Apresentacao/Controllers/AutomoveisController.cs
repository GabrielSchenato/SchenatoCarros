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
    public class AutomoveisController : Controller
    {
        private AutomovelRepositorio _repositorio = new AutomovelRepositorio();

        // GET: Automoveis
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Automoveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovel automovel = _repositorio.BuscarPor((int)id);
            if (automovel == null)
            {
                return HttpNotFound();
            }
            return View(automovel);
        }

        // GET: Automoveis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automoveis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Potencia,Placa,Km,ValorAluguel")] Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(automovel);
                return RedirectToAction("Index");
            }

            return View(automovel);
        }

        // GET: Automoveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovel automovel = _repositorio.BuscarPor((int)id);
            if (automovel == null)
            {
                return HttpNotFound();
            }
            return View(automovel);
        }

        // POST: Automoveis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Potencia,Placa,Km,ValorAluguel")] Automovel automovel)
        {
            Automovel automovelEditado = _repositorio.BuscarPor(automovel.Id);
            automovelEditado.Nome = automovel.Nome;
            automovelEditado.Potencia = automovel.Potencia;
            automovelEditado.Placa = automovel.Placa;
            automovelEditado.Km = automovel.Km;
            automovelEditado.ValorAluguel = automovel.ValorAluguel;
            if (ModelState.IsValid)
            {
                _repositorio.Editar(automovelEditado);
                return RedirectToAction("Index");
            }
            return View(automovel);
        }

        // GET: Automoveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovel automovel = _repositorio.BuscarPor((int)id);
            if (automovel == null)
            {
                return HttpNotFound();
            }
            return View(automovel);
        }

        // POST: Automoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovel automovel = _repositorio.BuscarPor((int)id);
            _repositorio.Deletar(automovel);
            return RedirectToAction("Index");
        }
    }
}
