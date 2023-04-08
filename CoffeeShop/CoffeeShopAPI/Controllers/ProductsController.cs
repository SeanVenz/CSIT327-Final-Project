using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController>  logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productdto">Product details</param>
        /// <returns>Returns the newly created product</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Products
        ///     {
        ///         "category": "Milk Shake"
        ///         "name" : "Coffee Milk Shake"
        ///         "description" : "A very refreshing drink"
        ///         "price" : 123.45
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a product.</response>
        /// <response code="400">Product details is invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreationDto productdto)
        {
            
            try
            {
                var newproduct = await _productService.CreateProduct(productdto);
                return CreatedAtRoute("GetProductById", new { id = newproduct.Id }, newproduct);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// <returns>Return all the products</returns>
        /// <remarks>
        /// Sample response:
        ///     
        ///     {
        ///         "id" : 1
        ///         "category": "Milk Shake"
        ///         "name" : "Coffee Milk Shake"
        ///         "description" : "A very refreshing drink"
        ///         "price" : 123.45
        ///     },
        ///     {
        ///         "id" : 2
        ///         "category": "Snack"
        ///         "name" : "French Fries"
        ///         "description" : "Fried potato slices"
        ///         "price" : 143.42
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully fetched all products</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Returns the product with the given id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Products/1
        ///     
        /// Sample response:
        /// 
        ///     {
        ///         "id": 1
        ///         "category": "Milk Shake"
        ///         "name" : "Coffee Milk Shake"
        ///         "description" : "A very refreshing drink"
        ///         "price" : 123.45
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully retrieved the product</response>
        /// <response code="404">Product with given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="productdto">New details of the product with the given id</param>
        /// <returns>Returns a message</returns>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT api/Products/1
        ///     {
        ///         "category": "Milk Shake"
        ///         "name" : "Coffee Milk Shake"
        ///         "description" : "A very refreshing drink"
        ///         "price" : 123.45
        ///     }
        ///     
        /// Sample response:
        /// 
        ///     Product with Id = 1 is successfully updated!
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated the product details</response>
        /// <response code="404">New product details are invalid</response>
        /// <response code="404">Product with given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductCreationDto productdto)
        {
            try
            {
                var check = await _productService.GetProduct(id);
                if(check == null)
                {
                    return BadRequest($"Product with Id = {id} is not found!");
                }
                await _productService.UpdateProduct(id, productdto);
                return Ok($"Product with Id = {id} is successfully updated!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Returns a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/Products/1
        /// 
        /// Sample response:
        ///     
        ///     Product with Id = 1 is successfully deleted!
        /// 
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var check = await _productService.GetProduct(id);
                if (check == null)
                {
                    return BadRequest($"Product with Id = {id} is not found!");
                }
                await _productService.DeleteProduct(id);
                return Ok($"Product with Id = {id} is successfully deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
