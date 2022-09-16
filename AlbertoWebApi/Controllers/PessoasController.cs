using AlbertoWebApi.Data;
using AlbertoWebApi.DTO;
using AlbertoWebApi.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var pessoas = _context.Pessoas.Include(c=>c.Departamento).Select(pessoa => new PessoaDTO 
            {
                DepartamentoId = pessoa.DepartamentoId,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Id = pessoa.Id,
                Departamento = new DepartamentoDTO 
                {
                    Nome = pessoa.Departamento.Nome,
                    Id = pessoa.Departamento.Id
                }
            });
            return Ok(pessoas);
        }
        
        [HttpPost]
        public IActionResult Insert(PessoaDTO pessoaDTO)
        {
            var pessoa = new Pessoa
            {
                DepartamentoId = pessoaDTO.DepartamentoId,
                Idade = pessoaDTO.Idade,
                Nome = pessoaDTO.Nome
            };
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
        public IActionResult Update(PessoaDTO pessoaDTO)
        {
            var pessoaASerAlterada = _context.Pessoas.Find(pessoaDTO.Id);
            pessoaASerAlterada.DepartamentoId = pessoaDTO.DepartamentoId;
            pessoaASerAlterada.Nome = pessoaDTO.Nome;
            pessoaASerAlterada.Idade = pessoaDTO.Idade;
            _context.Update(pessoaASerAlterada);
            _context.SaveChanges();
            return Ok();
        }
    }
}
