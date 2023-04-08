using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaristasController : ControllerBase
    {
        private readonly ILogger<BaristasController> _logger;
        private readonly IBaristaService _baristaService;

        public BaristasController(ILogger<BaristasController> logger, IBaristaService baristaService)
        {
            _logger = logger;
            _baristaService = baristaService;
        }


        /// <summary>
        /// Creates a barista 
        /// </summary>
        /// <param name="baristadto">Barista details</param>
        /// <returns>Returns the newly created barista</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Baristas
        ///     {
        ///         "name" : "John Doe"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a barista.</response>
        /// <response code="400">Barista details is invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaristaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBarista([FromBody] BaristaCreationDto baristadto)
        {
            try
            {
                var newbarista = await _baristaService.CreateBarista(baristadto);
                return CreatedAtRoute("GetBaristaById", new { id = newbarista.Id }, newbarista);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all the baristas
        /// </summary>
        /// <returns>Returns all baristas</returns>
        /// <remarks>
        /// Sample response:
        /// 
        ///     {
        ///         "id": 1,
        ///         "name": "Hugo Away"
        ///     },
        ///     {
        ///         "id": 3,
        ///         "name": "Rubin Pallea"
        ///     },
        ///     {
        ///         "id": 4,
        ///         "name": "Nicolea Lopez"
        ///     },
        ///     {
        ///         "id": 5,
        ///         "name": "Dia Stanes"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully fetched all baristas</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetAllBaristas")]
        public async Task<IActionResult> GetAllBaristas()
        {
            try
            {
                var baristas = await _baristaService.GetAllBaristas();
                return Ok(baristas);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a barista
        /// </summary>
        /// <param name="id">Barista id</param>
        /// <returns>Returns the barista with the given id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Baristas/1
        ///     
        /// Sample response:
        /// 
        ///     {
        ///         "id" : 1,
        ///         "name" : "John Doe"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully retrieved the barista</response>
        /// <response code="404">Barista with given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}", Name = "GetBaristaById")]
        public async Task<IActionResult> GetBarista(int id)
        {
            try
            {
                var barista = await _baristaService.GetBarista(id);
                return Ok(barista);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a barista
        /// </summary>
        /// <param name="id">Barista id</param>
        /// <param name="baristadto">New details of the barista with the given id</param>
        /// <returns>Returns a message</returns>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT api/Baristas/1
        ///     {
        ///         "name" : "John DoeDoe"
        ///     }
        ///     
        /// Sample response:
        /// 
        ///     Barista with Id = 1 is successfully updated!
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated the barista</response>
        /// <response code="404">New Barista details are invalid</response>
        /// <response code="404">Barista with given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> updateBarista(int id, [FromBody] BaristaCreationDto baristadto)
        {
            try
            {
                var check = await _baristaService.GetBarista(id);
                if (check == null)
                {
                    return BadRequest($"Barista with Id = {id} is not found!");
                }
                await _baristaService.UpdateBarista(id, baristadto);
                return Ok($"Barista with Id = {id} is successfully updated!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a barista
        /// </summary>
        /// <param name="id">Barista id</param>
        /// <returns>Returns a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/Baristas/1
        /// 
        /// Sample response:
        ///     
        ///     Customer with Id = 1 is successfully deleted!
        /// 
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarista(int id)
        {
            try
            {
                var check = await _baristaService.GetBarista(id);
                if (check==null)
                {
                    return BadRequest($"Barista with Id = {id} is not found!");
                }
                await _baristaService.DeleteBarista(id);
                return Ok($"Barista with Id = {id} is successfully deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
