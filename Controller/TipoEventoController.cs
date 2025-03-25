using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }
    

     /// <summary>
        /// Endpoint para listar tipos de eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_tipoEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para cadastras novos tipos de eventos
        /// </summary>
        /// <param name="novoTipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipoEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para buscar tipos de eventos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = _tipoEventoRepository.BuscarPorId(id);
                return Ok(tipoBuscado);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        /// <summary>
        /// Endpoint para deletar tipos de eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }


        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}










