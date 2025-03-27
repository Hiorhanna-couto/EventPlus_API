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

    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventosRepository;
        public EventoController(IEventoRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }


        [HttpGet]
        public IActionResult GetNextEvents(Guid id)
        {
            try
            {
                return Ok(_eventosRepository.ListarProximosEventos(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para cadastras Eventos
        /// </summary>
        /// <param name="novoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Eventos evento)
        {
            try
            {
                _eventosRepository.Cadastrar(evento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint para Deletar Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Eventos evento)
        {
            try
            {
                _eventosRepository.Atualizar(id, evento);
                return StatusCode(204, evento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para Listar Proximos Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok( _eventosRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// Endpoint para Listar Eventos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarPorId/{id}")]
        public IActionResult ListById(Guid id)
        {
            try
            {
                return Ok(_eventosRepository.ListarPorId(id));
            }
            catch (Exception)
            {
                return Ok(_eventosRepository.ListarPorId(id));
            }
        }
    }
}