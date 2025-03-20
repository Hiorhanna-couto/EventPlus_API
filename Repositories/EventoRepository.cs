using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

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
            return _context.Evento.Find(id)!;
        }

        public void Cadastrar(Eventos evento)
        {
            try
            {
                _context.Evento.Add(evento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o evento", ex);
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
                    _context?.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar o comentário do evento", ex);
            }
        }

        public List<Eventos> Listar()
        {
            return _context.Evento.ToList();
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            return _context.Evento.Where(e => e.EventosID == id).ToList();
        }

        public List<Eventos> ListarProximosEventos(Guid id)
        {
            return _context.Evento.Where(e => e.DataEvento > DateTime.Now).ToList();
        }
    }
}
