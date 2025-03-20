using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {

        private readonly Eventos_Context? _context;

        public PresencaEventoRepository(Eventos_Context? context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca PresencaBuscado = _context?.Presencas.Find(id)!;

                if (PresencaBuscado != null)
                {
                    PresencaBuscado.Situacao = presenca.Situacao;
                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            };
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                Presenca PresencasBuscado = _context?.Presencas.Find(id)!;
                return PresencasBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
           



        }

        public void Inscrever(Presenca inscreverPresenca)
        {
            throw new NotImplementedException();
        }

        public List<Presenca> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
