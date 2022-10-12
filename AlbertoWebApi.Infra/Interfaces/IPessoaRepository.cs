using AlbertoWebApi.Entites;

namespace AlbertoWebApi.Infra.Interfaces
{
    public interface IPessoaRepository
    {
        void Insert(Pessoa pessoa);
        Pessoa GetById(int id);
        void Update(Pessoa pessoaASerAlterada);
        void Delete(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
    }
}
