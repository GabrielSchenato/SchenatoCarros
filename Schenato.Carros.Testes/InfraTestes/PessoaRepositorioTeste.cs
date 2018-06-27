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
    public class PessoaRepositorioTeste
    {
        private CarrosContexto _contextoTeste;
        private PessoaRepositorio _repositorio;
        private Fisica _fisicaTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<CarrosContexto>());

            _contextoTeste = new CarrosContexto();

            _repositorio = new PessoaRepositorio();

            _fisicaTest = ConstrutorObjeto.CriarFisica();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_cliente()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_fisicaTest);

            //Afirmar
            var todosClientes = _contextoTeste.Pessoas.ToList();

            Assert.AreEqual(3, todosClientes.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_cliente()
        {
            //Preparação
            var clienteEditado = _contextoTeste.Pessoas.Find(1);
            clienteEditado.Nome = "EDITADO";

            //Ação
            _repositorio.Editar(clienteEditado);

            //Afirmar
            var clienteBuscado = _contextoTeste.Pessoas.Find(1);

            Assert.AreEqual("EDITADO", clienteBuscado.Nome);
        }

        [TestMethod]
        public void Deveria_deletar_um_cliente()
        {
            //Preparação
            var clienteDeletado = _contextoTeste.Pessoas.Find(1);

            //Ação
            _repositorio.Deletar(clienteDeletado);

            //Afirmar
            var todosClientes = _contextoTeste.Pessoas.ToList();

            Assert.AreEqual(1, todosClientes.Count);
        }

        [TestMethod]
        public void Deveria_buscar_cliente_por_id()
        {

            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarPor(1);

            //Afirmar

            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_clientes()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarTudo();

            //Afirmar

            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_clientes_fisicos()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarTudoFisica();

            //Afirmar

            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_clientes_juridicos()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarTudoJurido();

            //Afirmar

            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_cliente_por_cpf()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarPorCpf("10650799999");

            //Afirmar

            Assert.IsNotNull(clienteBuscado);
        }
        [TestMethod]
        public void Deveria_buscar_cliente_por_cnpj()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarPorCnpj("123456789");

            //Afirmar

            Assert.IsNotNull(clienteBuscado);
        }
    }
}
