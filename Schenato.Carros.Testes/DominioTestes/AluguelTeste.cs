using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Dominio.Excecoes;
using Schenato.Carros.Testes.Base;

namespace Schenato.Carros.Testes.DominioTestes
{
    [TestClass]
    public class AluguelTeste
    {
        private Aluguel _aluguel;

        [TestInitialize]
        public void Inicializador()
        {
            _aluguel = ConstrutorObjeto.CriarAluguel();
        }

        [TestMethod]
        public void Aluguel_deve_ter_um_cliente()
        {
            var _cliente = ConstrutorObjeto.CriarFisica();
            _aluguel.Cliente = _cliente;
            Assert.AreEqual(_cliente, _aluguel.Cliente);
        }

        [TestMethod]
        public void Aluguel_deve_ter_um_automovel()
        {
            var _automovel = ConstrutorObjeto.CriarAutomovel();
            _aluguel.Automovel = _automovel;

            Assert.AreEqual(_automovel, _aluguel.Automovel);
        }

        [TestMethod]
        public void Aluguel_deve_ter_uma_data_de_inicio()
        {
            Assert.AreEqual(DateTime.Now.ToShortDateString(), _aluguel.DataInicio.ToShortDateString());
        }

        [TestMethod]
        public void Aluguel_deve_ter_uma_data_de_fim()
        {
            Assert.AreEqual(DateTime.Now.AddDays(2).ToShortDateString(), _aluguel.DataFim.ToShortDateString());
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Aluguel_deve_ter_um_cliente_valido()
        {
            _aluguel.Cliente = null;

            _aluguel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Aluguel_deve_ter_um_automovel_valido()
        {
            _aluguel.Automovel = null;

            _aluguel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Aluguel_deve_ter_uma_data_de_inicio_valida()
        {
            _aluguel.DataInicio = new DateTime(0001, 01, 01);

            _aluguel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Aluguel_deve_ter_uma_data_de_fim_valida()
        {
            _aluguel.DataFim = new DateTime(0001, 01, 01);

            _aluguel.Validar();
        }

    }
}
