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
    public class JuridicosController : Controller
    {
        private PessoaRepositorio _repositorio = new PessoaRepositorio();

        // GET: Juridicos
        public ActionResult Index()
        {
            List<Juridico> juridicos = new List<Juridico>(_repositorio.BuscarTudoJurido().Cast<Juridico>());
            return View(juridicos);
        }

        // GET: Juridicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juridico juridico = (Juridico)_repositorio.BuscarPor((int)id);
            if (juridico == null)
            {
                return HttpNotFound();
            }
            return View(juridico);
        }

        // GET: Juridicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Juridicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Endereco,Cnpj")] Juridico juridico)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(juridico);
                return RedirectToAction("Index");
            }

            return View(juridico);
        }

        // GET: Juridicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juridico juridico = (Juridico)_repositorio.BuscarPor((int)id);
            if (juridico == null)
            {
                return HttpNotFound();
            }
            return View(juridico);
        }

        // POST: Juridicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Endereco,Cnpj")] Juridico juridico)
        {
            Juridico juridoEditado = (Juridico)_repositorio.BuscarPor(juridico.Id);
            juridoEditado.Nome = juridico.Nome;
            juridoEditado.Telefone = juridico.Telefone;
            juridoEditado.Endereco = juridico.Endereco;
            juridoEditado.Cnpj = juridico.Cnpj;
            if (ModelState.IsValid)
            {
                _repositorio.Editar(juridoEditado);
                return RedirectToAction("Index");
            }
            return View(juridico);
        }

        // GET: Juridicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juridico juridico = (Juridico)_repositorio.BuscarPor((int)id);
            if (juridico == null)
            {
                return HttpNotFound();
            }
            return View(juridico);
        }

        // POST: Juridicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Juridico juridico = (Juridico)_repositorio.BuscarPor((int)id);
            _repositorio.Deletar(juridico);
            return RedirectToAction("Index");
        }
    }
}
