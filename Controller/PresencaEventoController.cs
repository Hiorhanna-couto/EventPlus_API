using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : ControllerBase
    {
        public readonly IPresencaEventoRepository _presencaEventoRepository;

        public PresencaController(IPresencaEventoRepository presencaEventosRepository)
        {
            _presencaEventoRepository = presencaEventosRepository;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _presencaEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencaEventoRepository presencaBuscada = PresencaEventoRepository.BuscarPorId(id)!;
                return Ok(presencaBuscada);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpPut("id")]

        public IActionResult Put(Guid id, PresencaEventoRepository Presencas)
        {
            try
            {
                _presencaEventoRepository.Atualizar(id, Presenca);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Presenca> ListaDePresenca = _presencaEventoRepository.Listar();
                return Ok(ListaDePresenca);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Presenca> ListarPresencas = _presencaEventoRepository.ListarMinhasPresencas(id);
                return Ok(ListarPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpPost]

        public IActionResult Post(Presenca inscreverPresencaEventos)
        {
            try
            {
                _presencaEventoRepository.Inscrever(inscreverPresencaEventos);
                return Created();
            }

            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

    }
}

