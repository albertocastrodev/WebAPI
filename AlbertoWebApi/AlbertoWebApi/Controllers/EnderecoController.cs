using AlbertoWebApi.Data;
using AlbertoWebApi.DTO;
using AlbertoWebApi.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AlbertoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly AlbertoWebApiContext _context;

        public EnderecoController(AlbertoWebApiContext albertoWebApiContext)
        {

            _context = albertoWebApiContext;

        }

        [HttpPost]
        public IActionResult Insert(EnderecoDTO enderecoDTO)
        {
            var endereco = new Endereco
            {
                Bairro = enderecoDTO.Bairro,
                Logradouro = enderecoDTO.Logradouro,
                UF = enderecoDTO.UF,
                Cep = enderecoDTO.Cep,
                Cidade = enderecoDTO.Cidade,
                Numero = enderecoDTO.Numero
            };
            
            _context.Endereco.Add(endereco);
            _context.SaveChanges();

            return Ok(enderecoDTO);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var endereco = _context.Endereco.Select(c => new EnderecoDTO
            {
                Id = c.Id,
                Logradouro = c.Logradouro,
                Numero = c.Numero,
                Bairro = c.Bairro,
                Cidade = c.Cidade,
                Cep = c.Cep,
                UF = c.UF,
            });

            return Ok(endereco);

        }


        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var endereco = _context.Endereco.Find(id);
            var enderecoDTO = new EnderecoDTO
            {
                Id = endereco.Id,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Cep = endereco.Cep,
                UF = endereco.UF,

            };
            return Ok(enderecoDTO);
        }
    }
}
