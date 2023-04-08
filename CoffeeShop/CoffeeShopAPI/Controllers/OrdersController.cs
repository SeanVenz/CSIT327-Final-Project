using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Dtos.Order;
using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IBaristaService _baristaService;
        private readonly IProductService _productService;
        private readonly IPaymentService _paymentService;
        private readonly ICommentService _commentService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ICustomerService customerService, 
            IBaristaService baristaService, IProductService productService,
            IPaymentService paymentService, ICommentService commentService,
            ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _customerService = customerService;
            _baristaService = baristaService;
            _productService = productService;
            _paymentService = paymentService;
            _commentService = commentService;
            _logger = logger;
        }


        /// <summary>
        /// Creates an Order
        /// </summary>
        /// <param name="id">Id of the Customer</param>
        /// <param name="order">Order date</param>
        /// <returns>Returns newly created Order</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Orders/1/createOrder
        ///     {
        ///         "date" : "1/10/2022",
        ///         "customerId" : 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created an Order</response>
        /// <response code="400">Order details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("CreateOrder")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrderCreationDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreationDto order)
        {
            try
            {
                var newOrder = await _orderService.CreateOrder(order);

                return CreatedAtRoute("GetOrderById", new { id = newOrder.Id }, newOrder);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Assigns Barista/s to Order
        /// </summary>
        /// <param name="baristaId">Id of the Barista</param>
        /// <param name="orderId">Id of the Order</param>
        /// <returns>Returns newly created Order</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Orders/1/BaristaOrder
        ///     {
        ///         "baristaId" : "1",
        ///         "orderId" : 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created an BaristaOrder</response>
        /// <response code="400">BaristaOrder details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("{id}/Barista", Name = "AssignBaristaToOrder")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaristaOrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AssignBaristaToOrder([FromBody] int baristaId, int orderId)
        {
            try
            {
                var barista = await _baristaService.GetBarista(baristaId);
                var order = await _orderService.GetOrder(orderId);

                if (barista == null && order == null)
                    return NotFound($"Barista with Id = {baristaId} and Order with Id = {orderId} are not found");
                else if (barista == null)
                    return NotFound($"Barista with Id = {baristaId} is not found");
                else if (order == null)
                    return NotFound($"Order with Id = {orderId} is not found");

                await _orderService.AssignBaristaToOrder(baristaId, orderId);
                var orderWithBarista = await _orderService.GetOrder(orderId);

                return Ok(orderWithBarista);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Add Product/s to Order
        /// </summary>
        /// <param name="productId">Id of the Product</param>
        /// <param name="orderId">Id of the Order</param>
        /// <returns>Returns newly created Order</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Orders/1/ProductOrder
        ///     {
        ///         "productId" : "1",
        ///         "orderId" : 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created an ProductOrder</response>
        /// <response code="400">ProductOrder details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("{id}/Product", Name = "AddProductToOrder")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductOrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProductToOrder([FromBody] int productId, int orderId)
        {
            try
            {
                var product = await _productService.GetProduct(productId);
                var order = await _orderService.GetOrder(orderId);

                if (product == null && order == null)
                    return NotFound($"Product with Id = {productId} and Order with Id = {orderId} are not found");
                else if (product == null)
                    return NotFound($"Product with Id = {productId} is not found");
                else if (order == null)
                    return NotFound($"Order with Id = {orderId} is not found");

                await _orderService.AddProductToOrder(productId, orderId);
                var orderWithProduct = await _orderService.GetOrder(orderId);

                return Ok(orderWithProduct);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all Orders
        /// </summary>
        /// <returns>Returns all Orders</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Order
        ///     {
        ///         "id" : 1,
        ///         "date": "1/10/2022",
        ///         "customerId" : 1
        ///     },
        ///     {
        ///         "id" : 2,
        ///         "date": "1/10/2022",
        ///         "customerId" : 2
        ///     },
        ///     {
        ///         "id" : 3,
        ///         "date": "2/10/2022",
        ///         "customerId" : 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully retrieved Orders</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrderGetAllDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var order = await _orderService.GetAllOrders();
                if (order == null)
                {
                    return NoContent();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets an Order by Id
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <returns>Returns order with the Given Id</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Order/1
        ///     {
        ///         "id": 1,
        ///         "date": "Sean Venz Quijano",
        ///         "customerId": "Dumlog, Talisay City, Cebu",
        ///         "barista": [
        ///             {
        ///                 "name": "Barista AJ"
        ///             }
        ///         ]
        ///         "product": [
        ///             {
        ///                 "name": "Glazed Donut",
        ///                 "price": 50.00
        ///             }
        ///          ]
        ///     }
        /// </remarks>
        /// <response code="200">Successfully retrieved Order</response>
        /// <response code="404">Order with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await _orderService.GetOrder(id);
                if (order == null)
                {
                    return NotFound($"Order with Id = {id} is not found!");
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates an Order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <param name="order">Order updated details</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Order/{1}
        ///     {
        ///         "date": "5/10/2022",
        ///         "customerId": 1
        ///     }
        /// </remarks>
        /// <response code="200">Successfully updated an Order</response>
        /// <response code="400">Order details are invalid</response>
        /// <response code="404">Order is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateOrder")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrderCreationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderCreationDto order)
        {
            try
            {
                var check = await _orderService.GetOrder(id);
                if (check == null)
                    return NotFound($"Order with Id = {id} is not found");

                var update = await _orderService.UpdateOrder(id, order);
                var getUpdated = await _orderService.GetOrder(id);
                return Ok(getUpdated);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes an Order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <returns>Returns a Message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/Order/1
        ///         Order with Id = 1 was Successfully Deleted!
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a Order</response>
        /// <response code="404">Order with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var check = await _orderService.GetOrder(id);
                if (check == null)
                {
                    return BadRequest($"Order with Id = {id} is not found!");
                }
                await _orderService.DeleteOrder(id);
                return Ok($"Order with Id = {id} was successfully deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

    }
}
