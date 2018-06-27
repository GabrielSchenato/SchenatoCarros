using Schenato.Carros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Dominio.Entidades
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public virtual void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new DominioException("Nome inválido!");
            if (String.IsNullOrWhiteSpace(Telefone))
                throw new DominioException("Telefone inválido!");
            if (Endereco == null)
                throw new DominioException("Endereço inválido!");
        }
    }
}
