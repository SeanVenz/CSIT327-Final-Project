using AutoMapper;
using CoffeeShopAPI.Dtos.Comment;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Mappings
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentCreationDto, Comment>();
        }
    }
}
