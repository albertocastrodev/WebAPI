using AlbertoWebApi.DTO;

namespace AlbertoWebApi.Application.Interfaces
{
    public interface IPessoaApplication
    {
        void Insert(PessoaRequestDTO pessoaRequestDTO);
        void Update(PessoaRequestDTO pessoaDTO);
        void Delete(int id);
        List<PessoaResponseDTO> GetAll();
    }
}