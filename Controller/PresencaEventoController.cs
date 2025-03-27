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
    public class PresencaEventoController : ControllerBase
    {
        public readonly IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController(IPresencaEventoRepository presencaEventosRepository)
        {
            _presencaEventoRepository = presencaEventosRepository;
        }
        //-------------------------------------------------------------
        /// <summary>
        /// Endpoint para deletar presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
//------------------------------------------------------------------
        /// <summary>
        /// Endpoint para buscar por id as presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
               
                return Ok(_presencaEventoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
  //------------------------------------------------------------------
        /// <summary>
        /// Endpoint para Listar Presenças
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
                return Ok(_presencaEventoRepository.Listar());
            }
           
            catch (Exception e)
            {
                // Exceção genérica, caso o erro não seja do tipo ApplicationException
                return BadRequest( e.Message);
            }
        }
        //-----------------------------------------------------
        /// <summary>
        /// Endpoint para listar suas presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult GetByMe(Guid id)
        {
            try
            {
               
                return Ok(_presencaEventoRepository.ListarMinhasPresencas(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        //**********************************
        /// <summary>
        /// Endpoint para Inscrever(Cadastrar presença)
        /// </summary>
        /// <param name="novaPresenca"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Post(Presenca inscreverPresencaEventos)
        {
            try
            {
                _presencaEventoRepository.Inscrever(inscreverPresencaEventos);
                return StatusCode(201);
            }

            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

    }
}

