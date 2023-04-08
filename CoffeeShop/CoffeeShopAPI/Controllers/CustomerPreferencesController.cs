using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPreferencesController : ControllerBase
    {
        private readonly ICustomerPreferenceService _customerPreferenceService;
        private readonly ILogger<CustomerPreferencesController> _logger;

        public CustomerPreferencesController(ICustomerPreferenceService customerPreferenceService, ILogger<CustomerPreferencesController> logger)
        {
            _customerPreferenceService = customerPreferenceService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all Customer Preference
        /// </summary>
        /// <returns>Returns all Customer Preferences</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/CustomerPreference
        ///     {
        ///         "id" : 1,
        ///         "preference": "I love Strong Coffee",
        ///         "customerId" : 1
        ///     },
        ///     {
        ///         "id" : 2,
        ///         "preference": "I love sweet Coffee",
        ///         "customerId" : 2
        ///     },
        ///     {
        ///         "id" : 3,
        ///         "preference": "I love creamy Coffee",
        ///         "customerId" : 2
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully retrieved Customer Preferences</response>
        /// <response code="500">Internal server error</response>
        [HttpGet(Name = "GetAllCustomerPreferences")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerPreferenceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomerPreferencecs()
        {
            try
            {
                var customerPreference = await _customerPreferenceService.GetAllCustomerPreferences();
                if(customerPreference == null)
                {
                    return NoContent();
                }
                return Ok(customerPreference);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went Wrong");
            }
        }

        /// <summary>
        /// Get a Customer Preference
        /// </summary>
        /// <param name="id">Id of the Preference</param>
        /// <returns>Returns a Single Customer Preference</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/CustomerPreference/1
        ///     {
        ///         "id" : 1,
        ///         "preference": "I love Strong Coffee",
        ///         "customerId" : 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully retrieved Customer Preference</response>
        /// <response code="404">Customer Preference with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerPreferenceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetCustomerPreferenceById")] // GET /api/schools/{id} ex: /api/schools/-4.5
        public async Task<IActionResult> GetCustomerPreference(int id)
        {
            try
            {
                var customerPreference = await _customerPreferenceService.GetCustomerPreference(id);

                if (customerPreference == null)
                    return NotFound($"Customer Preference with id = {id} does not exist");

                return Ok(customerPreference);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a Customer Preference
        /// </summary>
        /// <param name="id">Customer Preference Id</param>
        /// <param name="customerPreference">Customer Preference Updated Details</param>
        /// <returns>Returns Newly Updated Customer Preference</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/CustomerPreference/1
        ///     {
        ///         "preference": "I dont like Strong coffee anymore"
        ///         "id" : 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated a Customer Preference</response>
        /// <response code="400">Customer PReference details are invalid</response>
        /// <response code="404">Customer Preference is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateCustomerPreference")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerPreferenceCreationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomerPreference(int id, [FromBody] CustomerPreferenceCreationDto customerPreference)
        {
             try
             {
                var check = await _customerPreferenceService.GetCustomerPreference(id);
                if(check == null)
                    return NotFound($"Customer Preference with Id = {id} is not found");

                var updatedPrefernece = await _customerPreferenceService.UpdatePreference(id, customerPreference);
                var getUpdated = await _customerPreferenceService.GetCustomerPreference(id);
                return Ok(getUpdated);
             }
             catch(Exception e)
             {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
             }
        }
    }
}
