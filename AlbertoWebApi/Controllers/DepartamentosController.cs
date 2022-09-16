using AlbertoWebApi.Data;
using AlbertoWebApi.DTO;
using AlbertoWebApi.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AlbertoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly AlbertoWebApiContext _context;

        public DepartamentosController(AlbertoWebApiContext albertoWebApiContext)
        {

            _context = albertoWebApiContext;

        }

        [HttpPost]
        public IActionResult Insert(DepartamentoDTO departamentoDTO)
        {
            var departamento = new Departamento { Nome = departamentoDTO.Nome };
            _context.Departamentos.Add(departamento);
            _context.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departamentos = _context.Departamentos.Select(c => new DepartamentoDTO
            {
                Id = c.Id,
                Nome = c.Nome
            });

            return Ok(departamentos);

        }


        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var departamento = _context.Departamentos.Find(id);
            var departamentoDTO = new DepartamentoDTO
            {
                Id = departamento.Id,
                Nome = departamento.Nome
            };
            return Ok(departamentoDTO);

        }
    }
}
