using EventPlus_.Context;

namespace EventPlus_.Repositories
{
    public class TiposUsuariosRepository
    {
        private readonly Eventos_Context? _Context;

        public TiposUsuariosRepository(Eventos_Context? context) 
        {
            _Context = context;
        }

        public void Atualizar(Guid id, TiposUsuariosRepository tiposUsuarios)
        {

        }

    }
}
