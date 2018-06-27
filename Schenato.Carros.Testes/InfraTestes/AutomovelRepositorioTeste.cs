using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Infraestrutura.Contexto;
using Schenato.Carros.Infraestrutura.Repositorios;
using Schenato.Carros.Testes.Base;

namespace Schenato.Carros.Testes.InfraTestes
{
    [TestClass]
    public class AutomovelRepositorioTeste
    {
        private CarrosContexto _contextoTeste;
        private AutomovelRepositorio _repositorio;
        private Automovel _automovelTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<CarrosContexto>());

            _contextoTeste = new CarrosContexto();

            _repositorio = new AutomovelRepositorio();

            _automovelTest = ConstrutorObjeto.CriarAutomovel();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_Automovel()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_automovelTest);

            //Afirmar
            var todosAutomoveis = _contextoTeste.Automoveis.ToList();

            Assert.AreEqual(2, todosAutomoveis.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_Automovel()
        {
            //Preparação
            var automovelEditado = _contextoTeste.Automoveis.Find(1);
            automovelEditado.Nome = "EDITADO";

            //Ação
            _repositorio.Editar(automovelEditado);

            //Afirmar
            var automovelBuscado = _contextoTeste.Automoveis.Find(1);

            Assert.AreEqual("EDITADO", automovelBuscado.Nome);
        }

        [TestMethod]
        public void Deveria_deletar_um_Automovel()
        {
            //Preparação
            var automovelDeletado = _contextoTeste.Automoveis.Find(1);

            //Ação
            _repositorio.Deletar(automovelDeletado);

            //Afirmar
            var todosAutomoveis = _contextoTeste.Automoveis.ToList();

            Assert.AreEqual(0, todosAutomoveis.Count);
        }

        [TestMethod]
        public void Deveria_buscar_Automovel_por_id()
        {

            //Preparação

            //Ação
            var automovelBuscado = _repositorio.BuscarPor(1);

            //Afirmar

            Assert.IsNotNull(automovelBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_Automoveis()
        {
            //Preparação

            //Ação
            var automovelBuscado = _repositorio.BuscarTudo();

            //Afirmar

            Assert.IsNotNull(automovelBuscado);
        }
    }
}
