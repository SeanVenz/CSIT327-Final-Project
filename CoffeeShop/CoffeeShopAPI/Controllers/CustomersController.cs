using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IPreferenceService _preferenceService;
        private readonly ICustomerPreferenceService _customerPreferenceService;
        private readonly ILogger<CustomersController> _logger;
        public CustomersController(ICustomerService customerService, IPreferenceService preferenceService, ICustomerPreferenceService customerPreferenceService , ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _preferenceService = preferenceService;
            _customerPreferenceService = customerPreferenceService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="customer">Customer Details</param>
        /// <returns>Returs Newly Created Customer</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/customers
        ///     {
        ///         "name" : "Sean Venz Quijano",
        ///         "address" : "Dumlog, Talisay City, Cebu",
        ///         "phoneNumber" : "09150193697"
        ///     }
        /// </remarks>
        /// <response code = "201">Successfully created a Customer</response>
        /// <response code = "400">Customer Details are invalid</response>
        /// <response code = "500">Internal Server Error</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationDto customer)
        {
            try
            {
                var newCustomer = await _customerService.CreateCustomer(customer);

                //If successfully created, STATUS CODE is 201
                // /api/customer/{id} add to header as location
                return CreatedAtRoute("GetCustomerById", new { id = newCustomer.Id }, newCustomer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all Customers with Preferences
        /// </summary>
        /// <returns>Returns all Customers with Preferences</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/Customer/GetAllCustomerWithPreferences
        ///     {
        ///         "id": 1,
        ///         "name": "Sean Venz Quijano",
        ///         "address": "Dumlog, Talisay City, Cebu",
        ///         "phoneNumber": "091515151515",
        ///         "customerPrefence": [
        ///             {
        ///                 "id": 1,
        ///                 "preference": "Chocolate donuts",
        ///                 "customerId": 1
        ///             },
        ///             {
        ///                 "id": 2,
        ///                 "preference": "Sweet donuts",
        ///                 "customerId": 1
        ///             }
        ///         ]
        ///     },
        ///     {
        ///         "id": 2.
        ///         "name" : "John Doe"
        ///         "address": "Doe Street"
        ///         "phoneNumber: "0969696969"
        ///         "customerPreference": [
        ///             {
        ///                 "id" : 3
        ///                 "preference" : "Strong coffee"
        ///                 "customerId" : 2
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <response code="200">Successfully retrieved Customers with Preferences</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetAllCustomersWithPreferences")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomersWithPreference()
        {
            try
            {
                var customer = await _customerService.GetAllCustomersWithPreference();
                if(customer == null)
                {
                    return NoContent();
                }
                return Ok(customer);
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all Customers
        /// </summary>
        /// <returns>Returns all Customers</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/Customer/GetAllCustomers
        ///     {
        ///         "id": 1,
        ///         "name": "Sean Venz Quijano",
        ///         "address": "Dumlog, Talisay City, Cebu",
        ///         "phoneNumber": "091515151515" 
        ///     },
        ///     {
        ///         "id": 2,
        ///         "name": "John Doe"
        ///         "address": Doe Street"
        ///         "phoneNumber": "0939393969"
        ///     }
        /// </remarks>
        /// <response code="200">Successfully retrieved Customers with Preferences</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetAllCustomers")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customer = await _customerService.GetAllCustomers();
                if(customer == null)
                {
                    return NoContent();
                }
                return Ok(customer);
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Returns customer with the Given Id</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Customer/1
        ///     {
        ///         "id": 1,
        ///         "name": "Sean Venz Quijano",
        ///         "address": "Dumlog, Talisay City, Cebu",
        ///         "phoneNumber": "091515151515" 
        ///     }
        /// </remarks>
        /// <response code="200">Successfully retrieved Customer</response>
        /// <response code="404">Customer with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetCustomerById")] // GET /api/schools/{id} ex: /api/schools/-4.5
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomer(id);
                if (customer == null)
                {
                    return NotFound($"Customer with Id = {id} is not found!");
                }
                return Ok(customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }


        /// <summary>
        /// Updates a Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <param name="customer">Customer updated details</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Customer/{1}
        ///     {
        ///         "name": "Leigh Quijano",
        ///         "address": "Dumlog, Talisay City, Cebu",
        ///         "phoneNumber": "09123456" 
        ///     }
        /// </remarks>
        /// <response code="200">Successfully updated a Customer</response>
        /// <response code="400">Customer details are invalid</response>
        /// <response code="404">Customer is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateCustomer")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerCreationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerCreationDto customer)
        {
            try
            {
                var check = await _customerService.GetCustomer(id);
                if(check == null)
                    return NotFound($"Customer with Id = {id} is not found");

                var update = await _customerService.UpdateCustomer(id, customer);
                var getUpdated = await _customerService.GetCustomer(id);
                return Ok(getUpdated);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Returns a Message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/Customer/1
        ///         Customer with Id = 1 was Successfully Deleted!
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a Customer</response>
        /// <response code="404">Customer with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var check = await _customerService.GetCustomer(id);
                if (check == null)
                {
                    return BadRequest($"Customer with Id = {id} is not found!");
                }
                await _customerService.DeleteCustomer(id);
                return Ok($"Customer with Id = {id} was Successfully Deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Creates a Preference
        /// </summary>
        /// <param name="id">Id of the Customer</param>
        /// <param name="customerPreference">Preference of the Customer</param>
        /// <returns>Returns newly created Preference</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Customer/1/createPreference
        ///     {
        ///         "preference" : "I Love Strong Coffee"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a Preference</response>
        /// <response code="400">Preference details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("{id}/createPreference", Name = "CreatePreferenceToCustomer")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerPreferenceDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePreference(int id, [FromBody] CustomerPreferenceDto customerPreference)
        {
            var newCustomerPreference = await _preferenceService.InsertPreference(id, customerPreference);
            try
            {
                return CreatedAtAction(
                nameof(CustomerPreferencesController.GetCustomerPreference),
                "CustomerPreferences",
                new { Id = newCustomerPreference },
                $"Customer Preference is Successfully Created"
                );
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a Customer Preference
        /// </summary>
        /// <param name="id">Id of the Customer Preference</param>
        /// <returns>Returns a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/Customer/1/deletePreference
        ///         Customer Preference with Id = 1 is successfully deleted
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted Customer Preference</response>
        /// <response code="404">Customer Preference with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}/deletePreference", Name = "DeletePreferenceOfCustomer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePreference(int id)
        {
            
            try
            {
                var check = await _customerPreferenceService.GetCustomerPreference(id);
                if (check == null)
                {
                    return BadRequest($"Customer Preference with Id = {id} does not exist!");
                }
                await _customerPreferenceService.DeleteCustomerPreference(id);
                return Ok($"Customer Preference with Id = {id} is successfully deleted");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
