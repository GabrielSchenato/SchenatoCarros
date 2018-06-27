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
    public class AluguelRepositorioTeste
    {
        private CarrosContexto _contextoTeste;
        private AluguelRepositorio _repositorio;
        private Aluguel _aluguelTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<CarrosContexto>());

            _contextoTeste = new CarrosContexto();

            _repositorio = new AluguelRepositorio();

            _aluguelTest = ConstrutorObjeto.CriarAluguel();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_Aluguel()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_aluguelTest);

            //Afirmar
            var todosAlugueis = _contextoTeste.Alugueis.ToList();

            Assert.AreEqual(3, todosAlugueis.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_Aluguel()
        {
            //Preparação
            var AluguelEditado = _repositorio.BuscarPor(1);
            AluguelEditado.DataFim = DateTime.Now.AddDays(15);

            //Ação
            _repositorio.Editar(AluguelEditado);

            //Afirmar
            var AluguelBuscado = _contextoTeste.Alugueis.Find(1);

            Assert.AreEqual(DateTime.Now.AddDays(15).ToShortDateString(), AluguelBuscado.DataFim.ToShortDateString());
        }

        [TestMethod]
        public void Deveria_deletar_um_Aluguel()
        {
            //Preparação
            var AluguelDeletado = _repositorio.BuscarPor(1);

            //Ação
            _repositorio.Deletar(AluguelDeletado);

            //Afirmar
            var todosAlugueis = _contextoTeste.Alugueis.ToList();

            Assert.AreEqual(1, todosAlugueis.Count);
        }

        [TestMethod]
        public void Deveria_buscar_Aluguel_por_id()
        {

            //Preparação

            //Ação
            var AluguelBuscado = _repositorio.BuscarPor(1);

            //Afirmar

            Assert.IsNotNull(AluguelBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_Alugueis()
        {
            //Preparação

            //Ação
            var AluguelBuscado = _repositorio.BuscarTudo();

            //Afirmar

            Assert.IsNotNull(AluguelBuscado);
        }
    }
}
