using CoffeeShopAPI.Dtos.Payment;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;
        
        public PaymentsController(IPaymentService paymentService,
            ILogger<PaymentsController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a payment
        /// </summary>
        /// <param name="paymentdto"></param>
        /// <returns>Newly created payment</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/customers
        ///     {
        ///         "amount" : "200.55!",
        ///         "paymentDate": "2/22/22",
        ///         "orderId" : "1"
        ///     }
        ///     
        /// </remarks>
        /// <response code = "201">Successfully created a Payment</response>
        /// <response code = "400">Comments are invalid</response>
        /// <response code = "500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentCreationDto paymentdto)
        {
            try
            {
                var newPayment = await _paymentService.CreatePayment(paymentdto);
                return CreatedAtRoute("GetPaymentById", new { id = newPayment.Id }, newPayment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all payments
        /// </summary>
        /// <returns>All payments</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/payments
        ///     {
        ///         "id": 1,
        ///         "amount" : "200.55!",
        ///         "paymentDate": "2/22/22",
        ///         "orderId" : "1"
        ///     }
        ///     
        ///     {
        ///         "id": 2,
        ///         "amount" : "500.55!",
        ///         "paymentDate": "3/12/22",
        ///         "orderId" : "2"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Successfully retrieved Payment</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetAllPayments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var payment = await _paymentService.GetAllPayments();
                if (payment == null)
                {
                    return NoContent();
                }
                return Ok(payment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a payment by Id
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>Payment with Id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/payments
        ///     {
        ///         "id": 1,
        ///         "amount" : "200.55!",
        ///         "paymentDate": "2/22/22",
        ///         "orderId" : "1"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Successfully retrieved Payment</response>
        /// <response code="404">Payment with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}", Name = "GetPaymentById")] // GET /api/payments/{id} ex: /api/payment/-4.5
        [Produces("application/json")]
        [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPayment(int id)
        {
            try
            {
                var payment = await _paymentService.GetPayment(id);
                if (payment == null)
                {
                    return NotFound($"Comment with Id = {id} is not found!");
                }
                return Ok(payment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a payment
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <param name="payment">updated Payment</param>
        /// <returns>Return a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/payments/{1}
        ///     {
        ///         "amount" : "250.55!",
        ///         "paymentDate": "1/21/22",
        ///         "orderId" : "1"
        ///     }   
        ///     Payment with Id = 1 was successfully updated!
        ///     
        /// </remarks>
        /// <response code="200">Successfully retrieved a Payment</response>
        /// <response code="400">Payments are invalid</response>
        /// <response code="404">Payment with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdatePayment")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PaymentCreationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] PaymentCreationDto payment)
        {
            try
            {
                await _paymentService.UpdatePayment(id, payment);
                return Ok($"Payment with Id = {id} was successfully updated!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Delete a payment
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>Return a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/Payment/1
        ///         Payment with Id = 1 was Successfully Deleted!
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a Payment</response>
        /// <response code="404">Payment with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                var check = await _paymentService.GetPayment(id);
                if (check == null)
                {
                    return BadRequest($"Comment with Id = {id} is not found!");
                }
                await _paymentService.DeletePayment(id);
                return Ok($"Payment with Id = {id} was successfully deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
