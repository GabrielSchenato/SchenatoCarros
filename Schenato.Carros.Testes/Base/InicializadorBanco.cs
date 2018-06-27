using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Testes.Base
{
    public class InicializadorBanco<T> : DropCreateDatabaseAlways<CarrosContexto>
    {
        protected override void Seed(CarrosContexto context)
        {
            //Cria automovel
            Automovel auto = new Automovel();
            auto.Nome = "Celta";
            auto.Potencia = 75;
            auto.Km = 50000;
            auto.Placa = "MJK-5050";
            auto.ValorAluguel = 150.00;

            //Criar fisica
            Fisica fisica = new Fisica();
            fisica.Nome = "Gabriel Schenato";
            fisica.Cpf = "10650799999";
            fisica.Telefone = "(49) 99431909";
            fisica.Renda = 5000;
            fisica.DataNascimento = DateTime.Now.AddYears(-20);

            fisica.Endereco = new Endereco
            {
                Cep = "88509900",
                Logradouro = "Avenida Marechal Castelo Branco",
                Complemento = "170",
                Bairro = "Universitário",
                Localidade = "Lages",
                Uf = "SC",
                Numero = "123"
            };

            //Criar juridico
            Juridico juridico = new Juridico();
            juridico.Nome = "Schenato";
            juridico.Cnpj = "123456789";
            juridico.Telefone = "(49) 32238080";

            juridico.Endereco = new Endereco
            {
                Cep = "88509900",
                Logradouro = "Avenida Marechal Castelo Branco",
                Complemento = "170",
                Bairro = "Universitário",
                Localidade = "Lages",
                Uf = "SC",
                Numero = "123"
            };

            //Cria aluguel pessoa fisica
            Aluguel aluguelFisica = new Aluguel();
            aluguelFisica.Cliente = fisica;
            aluguelFisica.Automovel = auto;
            aluguelFisica.DataInicio = DateTime.Now;
            aluguelFisica.DataFim = DateTime.Now.AddDays(2);

            //Fecha aluguel
            aluguelFisica.CalculaTotal();

            //Adicionar no contexto
            context.Alugueis.Add(aluguelFisica);

            //Cria aluguel pessoa juridica
            Aluguel aluguelJuridica = new Aluguel();
            aluguelJuridica.Cliente = juridico;
            aluguelJuridica.Automovel = auto;
            aluguelJuridica.DataInicio = DateTime.Now;
            aluguelJuridica.DataFim = DateTime.Now.AddDays(2);

            //Fecha aluguel
            aluguelJuridica.CalculaTotal();

            //Adicionar no contexto
            context.Alugueis.Add(aluguelJuridica);

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
