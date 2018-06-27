using Schenato.Carros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Dominio.Entidades
{
    public class Fisica : Pessoa
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Renda { get; set; }

        public void Validar() 
        {            
            if (String.IsNullOrWhiteSpace(Cpf))
                throw new DominioException("CPF inválido!");
            if (DataNascimento == new DateTime(0001, 01, 01))
                throw new DominioException("Data nascimento inválida!");
            if (Renda <= 0)
                throw new DominioException("Renda inválida!");
            base.Validar();
        }
    }
}
