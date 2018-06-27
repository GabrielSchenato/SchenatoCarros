using Schenato.Carros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Dominio.Entidades
{
    public class Aluguel
    {
        public int Id { get; set; }
        public virtual Pessoa Cliente { get; set; }
        public double ValorTotal { get; private set; }
        public virtual Automovel Automovel { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }


        public void Validar()
        {
            if (Cliente == null)
                throw new DominioException("Cliente inválido!");
            if (Automovel == null)
                throw new DominioException("Automovel inválido!");
            if (ValorTotal < 0)
                throw new DominioException("Valor total inválido!");
            if (DataInicio == new DateTime(0001, 01, 01))
                throw new DominioException("Data inicio inválida!");
            if (DataFim == new DateTime(0001, 01, 01) || DataFim < DataInicio)
                throw new DominioException("Data fim inválida!");
        }

        public void CalculaTotal()
        {
            TimeSpan data = DataFim.Subtract(DataInicio);
            ValorTotal = Automovel.ValorAluguel * (int)data.TotalDays;
        }
    }
}
