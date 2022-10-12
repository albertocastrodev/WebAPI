using AlbertoWebApi.Application.Interfaces;
using AlbertoWebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlbertoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaApplication _pessoaApplication;

        public PessoasController(IPessoaApplication pessoaApplication)
        {
            _pessoaApplication = pessoaApplication;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var pessoasResponseDTO = _pessoaApplication.GetAll();
            return Ok(pessoasResponseDTO);
        }

        [HttpPost]
        public IActionResult Insert(PessoaRequestDTO pessoaDTO)
        {
            _pessoaApplication.Insert(pessoaDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _pessoaApplication.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(PessoaRequestDTO pessoaDTO)
        {
            _pessoaApplication.Update(pessoaDTO);
            return Ok();
        }
    }
}
