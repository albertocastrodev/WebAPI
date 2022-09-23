using AlbertoWebApi.Data;
using AlbertoWebApi.DTO;
using AlbertoWebApi.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AlbertoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {


        private readonly AlbertoWebApiContext _context;

        public TelefonesController(AlbertoWebApiContext albertoWebApiContext)
        {

            _context = albertoWebApiContext;

        }

        [HttpPost]
        public IActionResult Insert(TelefoneDTO TelefonesDTO)
        {
            var telefone = new Telefone
            {

                DDD = TelefonesDTO.DDD,
                Numero = TelefonesDTO.Numero,
                Tipo = TelefonesDTO.Tipo


            };
            
            _context.Telefones.Add(telefone);
            _context.SaveChanges();
            return Ok();

        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var telefones = _context.Telefones.Select(c => new TelefoneDTO
            {
                Id = c.Id,
                DDD = c.DDD,
                Numero = c.Numero
                
            });

            return Ok(telefones);

        }


        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var telefone = _context.Telefones.Find(id);
            var TelefonesDTO = new TelefoneDTO
            {
                Id = telefone.Id,
                DDD = telefone.DDD,
                Numero = telefone.Numero,
                Tipo = telefone.Tipo,
            };
            return Ok(TelefonesDTO);

        }
    }
}
