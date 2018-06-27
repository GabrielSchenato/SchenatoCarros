using Schenato.Carros.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Schenato.Carros.Testes.Base
{
    public static class ConstrutorObjeto
    {
        public static Fisica CriarFisica()
        {
            return new Fisica
            {
                Id = 1,
                Nome = "Gabriel Schenato",
                Cpf = "10650799999",
                Telefone = "(49) 99431909",
                Renda = 5000,
                DataNascimento = DateTime.Now.AddYears(-20),
                Endereco = new Endereco
                {
                    Numero = "261",
                    Logradouro = "Av. Castelo Branco",
                    Bairro = "Universitário",
                    Localidade = "Lages",
                    Uf = "SC",
                    Cep = "88 987 876",
                    Complemento = ""
                },
            };
        }

        public static Juridico CriarJuridico()
        {
            return new Juridico
            {
                Id = 1,
                Nome = "Schenato",
                Cnpj = "123456789",
                Telefone = "(49) 32238080",
                Endereco = new Endereco
                {
                    Numero = "261",
                    Logradouro = "Av. Castelo Branco",
                    Bairro = "Universitário",
                    Localidade = "Lages",
                    Uf = "SC",
                    Cep = "88 987 876",
                    Complemento = ""
                },
            };
        }

        public static Aluguel CriarAluguel()
        {
            return new Aluguel
            {
                Id = 1,
                Cliente = CriarFisica(),
                Automovel = CriarAutomovel(),
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(2)
            };
        }

        public static Automovel CriarAutomovel()
        {
            return new Automovel
            {
                Id = 1,
                Nome = "Celta",
                Potencia = 75,
                Km = 50000,
                Placa = "MJK-5050",
                ValorAluguel = 150.00
            };
        }
    }
}
