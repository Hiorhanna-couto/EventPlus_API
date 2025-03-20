using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class TiposUsuariosRepository : ITipoUsuarioRepository
    {
        private readonly Eventos_Context? _context;

        public TiposUsuariosRepository(Eventos_Context? context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tiposUsuarioBuscado = _context?.TipoUsuarios.Find(id)!;

                if (tiposUsuarioBuscado != null)
                {
                    tiposUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuriosBuscado = _context?.TipoUsuarios.Find(id)!;
                return tipoUsuriosBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoUsuario novotipoUsuario )
        {
            try
            {
                _context?.TipoUsuarios.Add(novotipoUsuario);

                _context?.SaveChanges();
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
                TipoUsuario tipoUsuarioBuscado = _context?.TipoUsuarios.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context?.TipoUsuarios.Remove(tipoUsuarioBuscado);
                }

                _context?.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaDeUsuario = _context?.TipoUsuarios.ToList()!;
                return listaDeUsuario;

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
