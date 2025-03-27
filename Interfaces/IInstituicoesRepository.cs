using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IInstituicoesRepository
    {
      void Deletar(Guid id);
        void Atualizar(Guid id, Instituicao presenca);  
        List<Instituicao> Listar();

        List<Instituicao> ListarMinhasInstituicoes(Guid id);

        void Inscrever(Instituicao inscreverInstituicao);
        

    }
}
