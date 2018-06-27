using Schenato.Carros.Dominio.Contratos;
using Schenato.Carros.Dominio.Entidades;
using Schenato.Carros.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schenato.Carros.Infraestrutura.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        public CarrosContexto _contexto;

        public PessoaRepositorio()
        {
            _contexto = new CarrosContexto();
        }

        public void Adicionar(Pessoa entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Pessoas.Attach(entidade);
            }

            _contexto.Pessoas.Add(entidade);

            _contexto.SaveChanges();
        }

        public Pessoa BuscarPor(int id)
        {
            return _contexto.Pessoas.Find(id);
        }

        public Juridico BuscarPorCnpj(string cnpj)
        {
            return _contexto.Juridicos
                .Where(c => c.Cnpj == cnpj)
                .FirstOrDefault();
        }

        public Fisica BuscarPorCpf(string cpf)
        {
            return _contexto.Fisicas
                .Where(c => c.Cpf == cpf)
                .FirstOrDefault();
        }

        public List<Pessoa> BuscarTudo()
        {
            return _contexto.Pessoas.ToList();
        }
        public List<Fisica> BuscarTudoFisica()
        {
            return _contexto.Fisicas.Where(f => f.Cpf != null).ToList();
        }

        public List<Juridico> BuscarTudoJurido()
        {
            return _contexto.Juridicos.Where(j => j.Cnpj != null).ToList();
        }

        public void Deletar(Pessoa entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Pessoas.Attach(entidade);
            }

            _contexto.Pessoas.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Pessoa entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Pessoas.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
