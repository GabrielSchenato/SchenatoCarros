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
    public class AluguelRepositorio : IAluguelRepositorio
    {
        public CarrosContexto _contexto;

        public AluguelRepositorio()
        {
            _contexto = new CarrosContexto();
        }

        public void Adicionar(Aluguel entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Alugueis.Attach(entidade);
            }

            _contexto.Alugueis.Add(entidade);

            _contexto.SaveChanges();
        }

        public Aluguel BuscarPor(int id)
        {
            return _contexto.Alugueis.Find(id);
        }

        public List<Aluguel> BuscarTudo()
        {
            return _contexto.Alugueis.ToList();
        }

        public void Deletar(Aluguel entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Alugueis.Attach(entidade);
            }

            _contexto.Alugueis.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Aluguel entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Alugueis.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
