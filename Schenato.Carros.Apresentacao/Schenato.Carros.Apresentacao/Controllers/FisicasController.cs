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
    public class FisicasController : Controller
    {
        private PessoaRepositorio _repositorio = new PessoaRepositorio();

        // GET: Fisicas
        public ActionResult Index()
        {
            List<Fisica> fisicas = new List<Fisica>(_repositorio.BuscarTudoFisica().Cast<Fisica>());
            return View(fisicas);
        }

        // GET: Fisicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fisica fisica = (Fisica)_repositorio.BuscarPor((int)id);
            if (fisica == null)
            {
                return HttpNotFound();
            }
            return View(fisica);
        }

        // GET: Fisicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fisicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Endereco,Cpf,DataNascimento,Renda")] Fisica fisica)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(fisica);
                return RedirectToAction("Index");
            }

            return View(fisica);
        }

        // GET: Fisicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fisica fisica = (Fisica)_repositorio.BuscarPor((int)id);
            if (fisica == null)
            {
                return HttpNotFound();
            }
            return View(fisica);
        }

        // POST: Fisicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Endereco,Cpf,DataNascimento,Renda")] Fisica fisica)
        {
            Fisica fisicaEditada = (Fisica)_repositorio.BuscarPor(fisica.Id);
            fisicaEditada.Nome = fisica.Nome;
            fisicaEditada.Telefone = fisica.Telefone;
            fisicaEditada.Endereco = fisica.Endereco;
            fisicaEditada.Cpf = fisica.Cpf;
            fisicaEditada.DataNascimento = fisica.DataNascimento;
            fisicaEditada.Renda = fisica.Renda;
            if (ModelState.IsValid)
            {
                _repositorio.Editar(fisicaEditada);
                return RedirectToAction("Index");
            }
            return View(fisica);
        }

        // GET: Fisicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fisica fisica = (Fisica)_repositorio.BuscarPor((int)id);
            if (fisica == null)
            {
                return HttpNotFound();
            }
            return View(fisica);
        }

        // POST: Fisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fisica fisica = (Fisica)_repositorio.BuscarPor((int)id);
            _repositorio.Deletar(fisica);
            return RedirectToAction("Index");
        }
    }
}
