using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly Eventos_Context _context;

        public TipoEventoRepository(Eventos_Context context)
        {
            _context = context;
        }
    
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TipoEventos.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    tipoEventoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }
                _context.TipoEventos.Update(tipoEventoBuscado!);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoEventos.Find(id)!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            try
            {
                novoTipoEvento.TipoEventoID = Guid.NewGuid();

                _context.TipoEventos.Add(novoTipoEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TipoEventos.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    _context.TipoEventos.Remove(tipoEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> Listar()
        {
            try
            {
                return _context.TipoEventos
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
