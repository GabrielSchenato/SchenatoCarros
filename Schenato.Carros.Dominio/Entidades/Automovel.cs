using Schenato.Carros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Dominio.Entidades
{
    public class Automovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Potencia { get; set; }
        public string Placa { get; set; }
        public double Km { get; set; }
        public double ValorAluguel { get; set; }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new DominioException("Nome inválido!");
            if (Potencia <= 0)
                throw new DominioException("Potência inválida!");
            if (String.IsNullOrWhiteSpace(Placa))
                throw new DominioException("Placa inválida!");
            if (Km < 0)
                throw new DominioException("Km inválida!");
            if (ValorAluguel < 0)
                throw new DominioException("Valor Aluguel inválido!");
        }
    }
}
