using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Dominio.Excecoes;
using Schenato.Carros.Testes.Base;

namespace Schenato.Carros.Testes.DominioTestes
{
    [TestClass]
    public class AutomovelTeste
    {
        private Automovel _automovel;

        [TestInitialize]
        public void Inicializador()
        {
            _automovel = ConstrutorObjeto.CriarAutomovel();
        }

        [TestMethod]
        public void Automovel_deve_ter_um_nome()
        {
            Assert.AreEqual("Celta", _automovel.Nome);
        }

        [TestMethod]
        public void Automovel_deve_ter_uma_potencia()
        {
            Assert.AreEqual(75, _automovel.Potencia);
        }

        [TestMethod]
        public void Automovel_deve_ter_uma_km()
        {
            Assert.AreEqual(50000, _automovel.Km);
        }

        [TestMethod]
        public void Automovel_deve_ter_uma_placa()
        {
            Assert.AreEqual("MJK-5050", _automovel.Placa);
        }

        [TestMethod]
        public void Automovel_deve_ter_um_valor_de_aluguel_por_dia()
        {
            Assert.AreEqual(150.00, _automovel.ValorAluguel);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Automovel_deve_ter_um_nome_valido()
        {
            _automovel.Nome = "";

            _automovel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Automovel_deve_ter_uma_potencia_valida()
        {
            _automovel.Potencia = 0;

            _automovel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Automovel_deve_ter_uma_km_valida()
        {
            _automovel.Km = -10;

            _automovel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Automovel_deve_ter_uma_placa_valida()
        {
            _automovel.Placa = "";

            _automovel.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Automovel_deve_ter_um_valor_de_aluguel_valido()
        {
            _automovel.ValorAluguel = -500;

            _automovel.Validar();
        }

    }
}
