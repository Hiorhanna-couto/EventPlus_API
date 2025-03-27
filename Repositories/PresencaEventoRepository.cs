using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                    if (PresencaBuscado.Situacao == true)
                    {
                        PresencaBuscado.Situacao = false;
                    }
                    else
                    {
                        PresencaBuscado.Situacao = true;
                    }
                }
                _context?.Presencas.Update(PresencaBuscado!);
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
                return _context.Presencas
                   .Select(p => new Presenca
                   {
                       PresencaId = p.PresencaId,
                       Situacao = p.Situacao,

                       Eventos = new Eventos
                       {
                           EventosID = p.EventosID!,
                           DataEvento = p.Eventos!.DataEvento,
                           NomeEvento = p.Eventos.NomeEvento,
                           Descricao = p.Eventos.Descricao,

                           Instituicao = new Instituicao
                           {
                               InstituicaoID = p.Eventos.Instituicao!.InstituicaoID,
                               NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
                           }
                       }

                   }).FirstOrDefault(p => p.PresencaId == id)!;


            catch (Exception)
            {
                throw;
            }

        }
        [HttpPut("{id}")]
        public IActionResult Put()

        public void Inscrever(Presenca inscreverPresenca)
        {
            try
            {
                inscricao.IdPresencaEvento = Guid.NewGuid();
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
                return _context.Presencas
                    .Select(p => new Presenca
                    {
                        PresencaId = p.PresencaId,
                        Situacao = p.Situacao,

                        Eventos = new Eventos
                        {
                           EventosID = p.EventosID,
                            DataEvento = p.Eventos!.DataEvento,
                            NomeEvento = p.Eventos.NomeEvento,
                            Descricao = p.Eventos.Descricao,

                            Instituicao = new Instituicao
                            {
                                InstituicaoID = p.Eventos.Instituicao!.InstituicaoID,
                                NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
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
            
                return _context.Presencas
                 .Select(p => new Presenca
                 {
                     PresencaId = p.PresencaId,
                     Situacao = p.Situacao,
                     UsuarioID = p.UsuarioID,
                     EventosID = p.EventosID,

                     Eventos = new Eventos
                     {
                         EventoID = p.IdEvento,
                         DataEvento = p.Eventos!.DataEvento,
                         NomeEvento = p.Eventos!.NomeEvento,
                         Descricao = p.Eventos!.Descricao,

                         Instituicao = new Instituicoes
                         {
                             IdInstituicao = p.Evento!.IdInstituicao,
                         }
                     }
                 })
                 .Where(p => p.IdUsuario == id)
                 .ToList();
            }
        }
        }
    }
}

