using Schenato.Carros.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Dominio.Contratos
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Fisica BuscarPorCpf(string cpf);
        Juridico BuscarPorCnpj(string cnpj);
    }
}
