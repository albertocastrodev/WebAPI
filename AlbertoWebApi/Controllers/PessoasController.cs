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
            var pessoasResponseDTO = _context.Pessoas.Include(c => c.Departamento).Include(c => c.Endereco).Include(c=> c.Telefones).Select(pessoa => new PessoaResponseDTO
            {
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Id = pessoa.Id,
               
                Departamento = new DepartamentoDTO
                {
                    Nome = pessoa.Departamento.Nome,
                    Id = pessoa.Departamento.Id
                },
               
                Endereco = new EnderecoDTO
                {
                    Logradouro = pessoa.Endereco.Logradouro,
                    Numero = pessoa.Endereco.Numero,
                    Bairro = pessoa.Endereco.Bairro,
                    Cidade = pessoa.Endereco.Cidade,
                    Cep = pessoa.Endereco.Cep,
                    UF = pessoa.Endereco.UF
                },

                Telefones = new TelefonesDTO
                {
                
                    Id = pessoa.Telefones.Id,  
                    Tipo = pessoa.Telefones.Tipo, 
                    DDD = pessoa.Telefones.DDD,
                    NumeroTEL=pessoa.Telefones.NumeroTEL
                
                }
            });
            return Ok(pessoasResponseDTO);
        }

        [HttpPost]
        public IActionResult Insert(PessoaRequestDTO pessoaDTO)
        {
            var pessoa = new Pessoa
            {
                
                Idade = pessoaDTO.Idade,
                Nome = pessoaDTO.Nome,
                EnderecoId = pessoaDTO.EnderecoId,
                DepartamentoId = pessoaDTO.DepartamentoId,
                TelefonesId = pessoaDTO.TelefoneId,

            };


            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var pessoa = _context.Pessoas.Find(Id);
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(PessoaResponseDTO pessoaDTO)
        {
            var pessoaASerAlterada = _context.Pessoas.Find(pessoaDTO.Id);
           
            pessoaASerAlterada.Nome = pessoaDTO.Nome;
            pessoaASerAlterada.Idade = pessoaDTO.Idade;
            pessoaASerAlterada.EnderecoId = pessoaDTO.DepartamentoId;
            pessoaASerAlterada.DepartamentoId = pessoaDTO.DepartamentoId;
            pessoaASerAlterada.TelefonesId = pessoaDTO.DepartamentoId;
            _context.Update(pessoaASerAlterada);
            _context.SaveChanges();
            return Ok();
        }
    }
}
