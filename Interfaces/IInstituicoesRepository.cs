using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IInstituicoesRepository
    {
      void Deletar(Guid id);
        void Atualizar(Guid id, Instituicoes presenca);  
        List<Instituicoes> Listar();

        List<Instituicoes> ListarMinhasInstituicoes(Guid id);

        void Inscrever(Instituicoes inscreverInstituicao);
        

    }
}
