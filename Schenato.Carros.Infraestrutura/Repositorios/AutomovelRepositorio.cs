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
    public class AutomovelRepositorio : IAutomovelRepositorio
    {
        public CarrosContexto _contexto;

        public AutomovelRepositorio()
        {
            _contexto = new CarrosContexto();
        }

        public void Adicionar(Automovel entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Automoveis.Attach(entidade);
            }

            _contexto.Automoveis.Add(entidade);

            _contexto.SaveChanges();
        }

        public Automovel BuscarPor(int id)
        {
            return _contexto.Automoveis.Find(id);
        }

        public List<Automovel> BuscarTudo()
        {
            return _contexto.Automoveis.ToList();
        }

        public void Deletar(Automovel entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Automoveis.Attach(entidade);
            }

            _contexto.Automoveis.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Automovel entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Automoveis.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
