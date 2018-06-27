using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Dominio.Excecoes;
using Schenato.Carros.Testes.Base;

namespace Schenato.Carros.Testes.DominioTestes
{
    [TestClass]
    public class FisicaTeste
    {
        private Fisica _fisica;

        [TestInitialize]
        public void Inicializador()
        {
            _fisica = ConstrutorObjeto.CriarFisica();
        }

        [TestMethod]
        public void Fisica_deve_ter_um_nome()
        {
            Assert.AreEqual("Gabriel Schenato", _fisica.Nome);
        }

        [TestMethod]
        public void Fisica_deve_ter_um_cpf()
        {
            Assert.AreEqual("10650799999", _fisica.Cpf);
        }

        [TestMethod]
        public void Fisica_deve_ter_um_telefone()
        {
            Assert.AreEqual("(49) 99431909", _fisica.Telefone);
        }

        [TestMethod]
        public void Fisica_deve_ter_uma_renda()
        {
            Assert.AreEqual(5000, _fisica.Renda);
        }

        [TestMethod]
        public void Fisica_deve_ter_uma_data_de_nascimento()
        {
            Assert.AreEqual(DateTime.Now.AddYears(-20).ToShortDateString(), _fisica.DataNascimento.ToShortDateString());
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Fisica_deve_ter_um_nome_valido()
        {
            _fisica.Nome = "";

            _fisica.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Fisica_deve_ter_um_cpf_valido()
        {
            _fisica.Cpf = "";

            _fisica.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Fisica_deve_ter_um_telefone_valido()
        {
            _fisica.Telefone = "";

            _fisica.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Fisica_deve_ter_uma_renda_valida()
        {
            _fisica.Renda = -10;

            _fisica.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Fisica_deve_ter_uma_data_de_nascimento_valida()
        {
            _fisica.DataNascimento = new DateTime(0001, 01, 01);

            _fisica.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Fisica_deve_ter_um_endereco_valido()
        {
            var _fisica = ConstrutorObjeto.CriarFisica();

            _fisica.Endereco = null;

            _fisica.Validar();
        }
    }
}
