using Schenato.Carros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Dominio.Entidades
{
    public class Juridico : Pessoa
    {
        public string Cnpj { get; set; }

        public void Validar()
        {
            base.Validar();
            if (String.IsNullOrWhiteSpace(Cnpj))
                throw new DominioException("CNPJ inválido!");
        }
    }
}
