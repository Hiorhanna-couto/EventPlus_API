using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webapi.event_.Repositories
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
                Eventos eventoBuscado = _context.Evento.Find( id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.TipoEventoId = evento.TipoEventoId;
                }

                _context.Evento.Update(eventoBuscado!);

                _context.SaveChanges();
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
                return _context.Evento
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TipoEvento
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicao
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.EventosID == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Eventos evento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (evento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                evento.EventosID = Guid.NewGuid();

                _context.Evento.Add(evento);

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
                Eventos eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoId = e.TipoEventoId,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoId,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoId = e.InstituicaoId,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoId,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Include(e => e.Presenca)
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoId = e.TipoEventoId,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoId,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoId = e.InstituicaoId,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoId,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        },
                        Presenca = new Presenca
                        {
                            Usuario = e.Presenca!.Usuario,
                            Situacao = e.Presenca!.Situacao
                        }
                    })
                    .Where(e => e.Presenca!.Situacao == true && e.Presenca.UsuarioID == id)
                    .ToList();
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
                return _context.Evento
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoId = e.TipoEventoId,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoId,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoId = e.InstituicaoId,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoId,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
     