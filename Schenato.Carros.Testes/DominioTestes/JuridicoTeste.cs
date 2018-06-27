using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Dominio.Excecoes;
using Schenato.Carros.Testes.Base;

namespace Schenato.Carros.Testes.DominioTestes
{
    [TestClass]
    public class JuridicoTeste
    {
        private Juridico _juridico;

        [TestInitialize]
        public void Inicializador()
        {
            _juridico = ConstrutorObjeto.CriarJuridico();
        }

        [TestMethod]
        public void Jurido_deve_ter_um_nome()
        {
            Assert.AreEqual("Schenato", _juridico.Nome);
        }

        [TestMethod]
        public void Jurido_deve_ter_um_cnpj()
        {
            Assert.AreEqual("123456789", _juridico.Cnpj);
        }

        [TestMethod]
        public void Jurido_deve_ter_um_telefone()
        {
            Assert.AreEqual("(49) 32238080", _juridico.Telefone);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jurido_deve_ter_um_nome_valido()
        {
            _juridico.Nome = "";

            _juridico.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jurido_deve_ter_um_cnpj_valido()
        {
            _juridico.Cnpj = "";

            _juridico.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jurido_deve_ter_um_telefone_valido()
        {
            _juridico.Telefone = "";

            _juridico.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Juridico_deve_ter_um_endereco_valido()
        {
            var _juridico = ConstrutorObjeto.CriarJuridico();

            _juridico.Endereco = null;

            _juridico.Validar();
        }
    }
}
