using AlbertoWebApi.Data;
using AlbertoWebApi.Entites;
using AlbertoWebApi.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlbertoWebApi.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AlbertoWebApiContext _albertoWebApiContext;

        public PessoaRepository(AlbertoWebApiContext albertoWebApiContext)
        {
            _albertoWebApiContext = albertoWebApiContext;
        }

        public void Delete(Pessoa pessoa)
        {
            _albertoWebApiContext.Pessoas.Remove(pessoa);
            _albertoWebApiContext.SaveChanges();
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _albertoWebApiContext.Pessoas.Include(c=>c.Telefones).Include(c=>c.Departamento).Include(c=>c.Enderecos).ToList();
        }

        public Pessoa GetById(int id)
        {
            return _albertoWebApiContext.Pessoas.Find(id);
        }

        public void Insert(Pessoa pessoa)
        {
            _albertoWebApiContext.Pessoas.Add(pessoa);
            _albertoWebApiContext.SaveChanges();
        }

        public void Update(Pessoa pessoaASerAlterada)
        {
            _albertoWebApiContext.Pessoas.Update(pessoaASerAlterada);
            _albertoWebApiContext.SaveChanges();
        }
    }
}
