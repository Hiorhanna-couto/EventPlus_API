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
                return _context?.Presencas
                    .Select(p => new Presenca
                    {
                        PresencaID = p.PresencaID,
                        Situacao = p.Situacao,

                        Eventos = new Eventos
                        {
                            EventosID = p.EventosID!,
                            DataEvento = p.Eventos!.DataEvento,
                            NomeEvento = p.Eventos.NomeEvento,
                            Descricao = p.Eventos.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Eventos.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresencaEvento == id)!;
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
                Presenca presencaEventoBuscado = _context?.Presencas.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context?.Presencas.Remove(presencaEventoBuscado);
                }

                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }



        }

        public void Inscrever(Presenca inscreverPresenca)
        {
            try
            {
                inscreverPresenca.PresencaID = Guid.NewGuid();

                _context?.Presencas.Add(inscreverPresenca);

                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> Listar()
        {

            try
            {
                return _context?.Presencas
                    .Select(p => new Presenca
                    {
                        PresencaID = p.PresencaID,
                        Situacao = p.Situacao,

                        Eventos = new Eventos
                        {
                            EventosID = p.EventosID,
                            DataEvento = p.Eventos!.DataEvento,
                            NomeEvento = p.Eventos.NomeEvento,
                            Descricao = p.Eventos.Descricao,

                            InstituicaoID = new Instituicoes
                            {
                                InstituicaoID = p.Eventos.InstituicaoID!.Instituicao,
                                NomeFantasia = p.Eventos?.InstituicaoID!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

      

        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            return _context?.Presencas
                .Select(p => new Presenca
                {
                    PresencaID = p.PresencaID,
                    Situacao = p.Situacao,
                    Usuario = p.Usuario,
                    EventosID = p.EventosID,

                    Eventos = new Eventos
                    {
                        EventosID = p.EventosID,
                        DataEvento = p.Eventos!.DataEvento,
                        NomeEvento = p.Eventos!.NomeEvento,
                        Descricao = p.Eventos!.Descricao,

                        InstituicaoID = new Instituicoes
                        {
                            InstituicaoID = p.EventosID!.Instituicao!,
                        }
                    }
                })
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
    }

