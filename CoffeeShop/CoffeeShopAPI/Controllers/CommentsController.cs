using CoffeeShopAPI.Dtos.Comment;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ICommentService commentService,
            ILogger<CommentsController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a comment
        /// </summary>
        /// <param name="commentdto">Comments</param>
        /// <returns>Newly created comment</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/comments
        ///     {
        ///         "comments" : "Great service!",
        ///         "orderId" : "1"
        ///     }
        ///     
        /// </remarks>
        /// <response code = "201">Successfully created a Comment</response>
        /// <response code = "400">Comments are invalid</response>
        /// <response code = "500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreationDto commentdto)
        {
            try
            {
                var newComment = await _commentService.CreateComment(commentdto);

                //If successfully created, STATUS CODE is 201
                // /api/comment/{id} add to header as location
                return CreatedAtRoute("GetCommentById", new { id = newComment.Id }, newComment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns>All comments</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/comments
        ///     {
        ///         "id": 1,
        ///         "comments" : "Great service!",
        ///         "orderId" : "1"
        ///     }
        ///     
        ///     {
        ///         "id": 2,
        ///         "comments" : "love it!",
        ///         "orderId" : "2"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Successfully retrieved Comments</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetAllComments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                var comment = await _commentService.GetAllComments();
                if (comment == null)
                {
                    return NoContent();
                }
                return Ok(comment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a comment by Id
        /// </summary>
        /// <param name="id">Comment Id</param>
        /// <returns>comment with Id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/comments/1
        ///     {
        ///         "id": 1,
        ///         "comments" : "Great service!",
        ///         "orderId" : "1"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Successfully retrieved a Comment</response>
        /// <response code="404">Comment with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}", Name = "GetCommentById")] // GET /api/comments/{id} ex: /api/comment/-4.5
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetComment(int id)
        {
            try
            {
                var comment = await _commentService.GetComment(id);
                if (comment == null)
                {
                    return NotFound($"Comment with Id = {id} is not found!");
                }
                return Ok(comment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="id">Comment Id</param>
        /// <param name="comment">Updated Comment</param>
        /// <returns>Return a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/comments/{1}
        ///     {
        ///         "comments" : "Love it!",
        ///         "orderId" : "1"
        ///     }
        ///     Comment with Id = 1 was successfully updated!
        ///     
        /// </remarks>
        /// <response code="200">Successfully retrieved a Comment</response>
        /// <response code="400">Comments are invalid</response>
        /// <response code="404">Comment with the given id is not found</response>
        /// <response code="500">Internal server error</response>        
        [HttpPut("{id}", Name = "UpdateComment")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommentCreationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentCreationDto comment)
        {
            try
            {
                // Check if comment exists
                await _commentService.UpdateComment(id, comment);                
                return Ok($"Comment with Id = {id} was successfully updated!");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a comments
        /// </summary>
        /// <param name="id"> Comments Id</param>
        /// <returns>Return a message</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE/api/comment/1
        ///         Comment with Id = 1 was Successfully Deleted!
        ///         
        /// </remarks> 
        /// <response code="200">Successfully deleted a Comment</response>
        /// <response code="404">Comment with the given id is not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var check = await _commentService.GetComment(id);
                if (check == null)
                {
                    return BadRequest($"Comment with Id = {id} is not found!");
                }
                await _commentService.DeleteComment(id);
                return Ok($"Comment with Id = {id} was successfully deleted!");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
