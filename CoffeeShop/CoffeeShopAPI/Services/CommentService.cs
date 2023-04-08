using AutoMapper;
using CoffeeShopAPI.Dtos.Comment;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;
using System.Collections.Generic;

namespace CoffeeShopAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateComment(CommentCreationDto CommentDto)
        {
            var commentModel = _mapper.Map<Comment>(CommentDto);
            commentModel.Id = await _repository.CreateComment(commentModel);
            return _mapper.Map<CommentDto>(commentModel);
        }

        public async Task<bool> DeleteComment(int id)
        {
            return await _repository.DeleteComment(id);

        }

        public async Task<IEnumerable<CommentDto>> GetAllComments()
        {
            var commentModel = await _repository.GetAllComments();
            return _mapper.Map<IEnumerable<CommentDto>>(commentModel);
        }

        public async Task<CommentDto?> GetComment(int id)
        {          
            var model = await _repository.GetComment(id);
            if (model == null) return null;

            return _mapper.Map<CommentDto>(model);
        }

        public async Task UpdateComment(int commentId, CommentCreationDto commentToUpdate)
        {
            var commentModel = new Comment
            {
                Id = commentId,
                Comments = commentToUpdate.Comments,
                OrdersId = commentToUpdate.OrdersId
            };
            var comment = await _repository.UpdateComment(commentModel);
        }

    }
}
