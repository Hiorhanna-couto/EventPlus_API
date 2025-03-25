using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Eventos_Context? _context;
        

        public ComentarioEventoRepository(Eventos_Context? context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventosId)
        {
            try
            {
                return _context?.ComentarioEventos
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventosID = c.EventosID,

                        Usuario = new Usuario
                        {
                            UsuarioID = c.Usuario!.UsuarioID
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.UsuarioID == UsuarioId && c.EventosID == EventosId)!;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void Cadastrar(ComentarioEvento comentarioEventosid)
        {

            try
            {
                comentarioEventosid.ComentarioEventoID = Guid.NewGuid();

                _context?.ComentarioEventos.Add(comentarioEventosid);

                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid idComentario)
        {
            try
            {
                ComentarioEvento ComentarioEventoBuscado = _context?.ComentarioEventos.Find(idComentario)!;

                if (ComentarioEventoBuscado != null)
                {
                    _context?.ComentarioEventos.Remove(ComentarioEventoBuscado);
                    _context?.SaveChanges();
                }

            }
            catch (Exception )
            {

                throw ;
            }
         

        }

        public List<ComentarioEvento>? Listar(Guid  id)
        {
            try
            {
                return _context?.ComentarioEventos
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventosID = c.EventosID,

                        Usuario = new Usuario
                        {
                            UsuarioID = c.Usuario!.UsuarioID
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.EventosID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ComentarioEvento> Listar()
        {
            throw new NotImplementedException();
        }

        public List<ComentarioEvento>? ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context?.ComentarioEventos
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventosID = c.EventosID,

                        Usuario = new Usuario
                        {
                            UsuarioID = c.Usuario!.UsuarioID
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.EventosID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
