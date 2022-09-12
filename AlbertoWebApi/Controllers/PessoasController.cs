using AlbertoWebApi.Data;
using AlbertoWebApi.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlbertoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly AlbertoWebApiContext _context;

        public PessoasController(AlbertoWebApiContext albertoWebApiContext)
        {

            _context = albertoWebApiContext;

        }



        [HttpGet]
        public IActionResult GetAll()
        {


            var pessoas = _context.Pessoas.ToList();
            return Ok(pessoas);

        }

        [HttpPost]
        public IActionResult Insert(Pessoa pessoa)
        {


            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(int Id) {
            
            var pessoa = _context.Pessoas.Find(Id);
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Pessoa pessoa)
        {

            var pessoaASerAlterada = _context.Pessoas.Find(pessoa.Id);
            pessoaASerAlterada.Nome = pessoa.Nome;
            pessoaASerAlterada.Idade = pessoa.Idade;
            pessoaASerAlterada.Departamento = pessoa.Departamento;
            _context.Update(pessoaASerAlterada);
            return Ok();
        }
    }
}
