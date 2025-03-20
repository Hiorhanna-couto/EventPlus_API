using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Utils;

namespace EventPlus_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly Eventos_Context? _context;

        public UsuarioRepository(Eventos_Context? context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context?.Usuarios.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }

                }
                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario UsuriosBuscado = _context?.Usuarios.Find(id)!;
                return UsuriosBuscado;

            }
            catch (Exception)
            {
                throw;
            }
         
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _context?.Usuarios.Add(novoUsuario);

                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
