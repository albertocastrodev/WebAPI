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
        public IActionResult Insert(TelefonesDTO TelefonesDTO)
        {
            var telefone = new Telefones
            {

                DDD = TelefonesDTO.DDD,
                NumeroTEL = TelefonesDTO.NumeroTEL,
                Tipo = TelefonesDTO.Tipo


            };
            
            _context.Telefones.Add(telefone);
            _context.SaveChanges();
            return Ok();

        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var telefones = _context.Telefones.Select(c => new TelefonesDTO
            {
                Id = c.Id,
                DDD = c.DDD,
                NumeroTEL = c.NumeroTEL
                
            });

            return Ok(telefones);

        }


        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var telefone = _context.Telefones.Find(id);
            var TelefonesDTO = new TelefonesDTO
            {
                Id = telefone.Id,
                DDD = telefone.DDD,
                NumeroTEL = telefone.NumeroTEL,
                Tipo = telefone.Tipo,
            };
            return Ok(TelefonesDTO);

        }
    }
}
