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
                ComentarioEvento ComentarioEventoBuscado = _context?.ComentarioEventos.FirstOrDefault(u => u.Email == email)!;

                if (ComentarioEventoBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha,  ComentarioEventoBuscado.Senha!);

                    if (confere)
                    {
                        return ComentarioEventoBuscado;
                    }

                }
                return null!;

            }
            catch (Exception)
            {

                throw;
            }


        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            throw new NotImplementedException();
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
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar o comentário do evento", ex);
            }
         

        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                List<ComentarioEvento> listaDeComentarioEvento = _context?.ComentarioEventos.ToList()!;
                return listaDeComentarioEvento;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
