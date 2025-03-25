using System.Diagnostics;
using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventPlus_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Eventos_Context _context;

        public EventoRepository(Eventos_Context context)
        {
            _context = context;
        }


        public void Atualizar(Guid id, Eventos evento)
        {

          
                try
                {
                Eventos EventosBuscado = _context?.Evento.Find(id)!;

                    if (EventosBuscado != null)
                    {
                        EventosBuscado.NomeEvento = evento.NomeEvento;
                        EventosBuscado.DataEvento = evento.DataEvento;
                        EventosBuscado.Descricao = evento.Descricao;
                        EventosBuscado.TipoEvento = evento.TipoEvento;
                }
                    _context?.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            
        }

        public Eventos BuscarPorId(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _context.Evento.Find(id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Eventos novoEvento)
        {
            try
            {
                _context.Evento.Add(novoEvento);
                _context.SaveChanges();
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Eventos EventoBuscado = _context?.Evento.Find(id)!;

                if (EventoBuscado != null)
                {
                    _context?.Evento.Remove(EventoBuscado);
                }

              _context?.SaveChanges();
            }
            catch (Exception )
            {

                throw ;
            }
        }


        public List<Eventos> Listar(Guid id )
        {
            try
            {
                List<Eventos> listaDeEventos = _context.Evento.ToList();
                return listaDeEventos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Eventos> ListarPorId(Guid EventosID)
        {
            try
            {
                List<Eventos> listaEventoPorId = _context.Evento

                    .Include(g => g.EventosID).Where(f => f.EventosID == EventosID)
                    .ToList();

                return listaEventoPorId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ListarProximosEventos(Guid id)
        {
            try
            {
                List<Eventos> listaProximosEventos = _context.Evento.ToList();
                return listaProximosEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
